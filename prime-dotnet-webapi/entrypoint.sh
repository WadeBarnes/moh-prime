#!/bin/bash
echo "Running the migrations..."
#psql -d postgres -f databaseMigration.sql

if [ -z "${DB_CONNECTION_STRING}" ]
then
export DB_CONNECTION_STRING="host=${DB_HOST};port=5432;database=${POSTGRES_DATABASE};username=${POSTGRES_USERNAME};password=${POSTGRES_ADMIN_PASSWORD}"
fi
export AUTH=$(printf $PHARMANET_API_USERNAME:$PHARMANET_API_PASSWORD|base64)
export logfile=prime.logfile.out
# Wait for database connection
function PG_IS_READY() { 
psql -h $DB_HOST -U ${POSTGRES_USERNAME} -d ${POSTGRES_DATABASE} -t -c "select 'READY'"
}


n=0
while  [[ $n -ge 5 || ($(PG_IS_READY) == *"READY"*) ]]
do
    echo "Waiting for the database ..." ;
    sleep 3 ;
    n=$[$n+1]
done
if [[ $n -ge 5 ]]
then
    echo "Failed to connect to database."
    exit 1
fi


psql -h $DB_HOST -U ${POSTGRES_USERNAME} -d ${POSTGRES_DATABASE} -a -f ./out/databaseMigrations.sql

echo "Resting 5 seconds to let things settle down..."
echo "Running .NET..."
dotnet ./out/prime.dll -v 2>&1> $logfile &
echo "Launched, waiting for connection to API internally..."

function waitForIt() {
until [[ "$response" -eq "$2" ]]
do
    echo "Waiting for the host ..." ;
    sleep 1 ;
    response=`curl -s -o /dev/null -w "%{http_code}" $1`
done
echo "$1 responded $2"
}

function pharmanetCheck() {
    UUID=$(cat /proc/sys/kernel/random/uuid)
    AUTH=$(printf $PHARMANET_API_USERNAME:$PHARMANET_API_PASSWORD|base64)
    printf {\"applicationUUID\":\"${UUID}\"\,\"programArea\":\"PRIME\"\,\"licenceNumber\":\"20361\"\,\"collegeReferenceId\":\"P1\"} > /tmp/data.out
    openssl pkcs12 -in $PHARMANET_SSL_CERT_FILENAME -out /tmp/pharmanet-api-cert.pem -nodes -passin pass:$PHARMANET_SSL_CERT_PASSWORD
    curl -s -o /dev/null -w "%{http_code}" --cert /tmp/pharmanet-api-cert.pem \
    -H "Authorization: Basic $AUTH" \
    -H "Content-Type: application/json" $PHARMANET_API_URL \
    -H "Accept: application/json" \
    --data "@/tmp/data.out"
}

function pharmanetVerboseCheck() {
    UUID=$(cat /proc/sys/kernel/random/uuid)
    AUTH=$(printf $PHARMANET_API_USERNAME:$PHARMANET_API_PASSWORD|base64)
    printf {\"applicationUUID\":\"${UUID}\"\,\"programArea\":\"PRIME\"\,\"licenceNumber\":\"20361\"\,\"collegeReferenceId\":\"P1\"} > /tmp/data.out
    openssl pkcs12 -in $PHARMANET_SSL_CERT_FILENAME -out /tmp/pharmanet-api-cert.pem -nodes -passin pass:$PHARMANET_SSL_CERT_PASSWORD
    curl -v -s -o /dev/null --cert /tmp/pharmanet-api-cert.pem \
    -H "Authorization: Basic $AUTH" \
    -H "Content-Type: application/json" $PHARMANET_API_URL \
    -H "Accept: application/json" \
    --data "@/tmp/data.out"
}

waitForIt localhost:${API_PORT}/api/enrollees 401 2>&1 | logger &
waitForIt localhost:${API_PORT}/api/lookups 401 2>&1 | logger

echo -e "\nThe system is up."

tail -f $logfile
