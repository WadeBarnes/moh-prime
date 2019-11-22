import { Component, Input, ContentChildren, QueryList } from '@angular/core';
import { MenuPositionX, MenuPositionY } from '@angular/material';
import { ContextualTitleDirective } from '../contextual-title.directive';
import { ContextualContentDirective } from '../contextual-content.directive';

@Component({
  selector: 'app-contextual-help',
  templateUrl: './contextual-help.component.html',
  styleUrls: ['./contextual-help.component.scss']
})
export class ContextualHelpComponent {
  // Allow for small adjustments to the position of the icon the container
  @Input() cssClass: string;
  @Input() xPosition: MenuPositionX = 'after';
  @Input() yPosition: MenuPositionY = 'below';

  @ContentChildren(ContextualTitleDirective, { descendants: true })
  public contextualHelpTitleChildren: QueryList<ContextualTitleDirective>;
  @ContentChildren(ContextualContentDirective, { descendants: true })
  public contextualHelpContentChildren: QueryList<ContextualContentDirective>;

  constructor() { }
}
