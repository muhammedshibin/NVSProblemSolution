import { LandmarkService } from './../landmark.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-landmark',
  templateUrl: './add-landmark.component.html',
  styleUrls: ['./add-landmark.component.css'],
})
export class AddLandmarkComponent implements OnInit {
  landmarkForm: FormGroup;
  formattedAddress: string;

  constructor(
    private fb: FormBuilder,
    private landmarkService: LandmarkService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.createLandmarkForm();
  }

  createLandmarkForm() {
    this.landmarkForm = this.fb.group({
      landmarkName: [null, [Validators.required]],
      address: [null],
      latitude: [null, [Validators.required]],
      longitude: [null, [Validators.required]],
      contactNumber: [null, [Validators.required]],
    });
  }

  onSubmit() {
    this.landmarkService.saveLandmark(this.landmarkForm.value).subscribe(
      (response) => {
        this.toastr.success("Landmark Added Succesfully","Success");
      },
      (err) => {
        this.toastr.error(err.error);
      }
    );
  }  

  handleAddressChange(address: any) {
    this.landmarkForm.patchValue({
      address:address.formatted_address,
      latitude: address.geometry.location.lat(),
      longitude:address.geometry.location.lng()
    })
  }
}


