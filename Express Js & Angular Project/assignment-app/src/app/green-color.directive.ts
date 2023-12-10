import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
  selector: '[appGreenColor]'
})
export class GreenColorDirective {



  constructor(private el: ElementRef, private renderer: Renderer2) {
    // Set the background color to green
    this.renderer.setStyle(this.el.nativeElement, 'background-color', 'green');
  }

}
