import { Component, ElementRef, Input, OnInit, Self, ViewChild } from '@angular/core';
import { ControlValueAccessor, NgControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})
export class TextInputComponent implements OnInit , ControlValueAccessor {

  @ViewChild('input',{static: true}) input : ElementRef;
  @Input() type = 'text';
  @Input() label: string;
  @Input() isRequired =false;

  constructor(@Self() public controlDir: NgControl) {
    this.controlDir.valueAccessor = this;    
   }

  writeValue(obj: any): void {
    this.input.nativeElement.value = obj || '';
  }
  registerOnChange(fn: any): void {
    this.onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  onChange(event:any) {}

  onTouched() {}


  ngOnInit(): void {
    const control = this.controlDir.control;
    
    if(control && control.validator){
      const validator = control.validator;

      if(validator){
        control?.setValidators([validator]);
      }
    }  
    
    control!.updateValueAndValidity();
  }

}
