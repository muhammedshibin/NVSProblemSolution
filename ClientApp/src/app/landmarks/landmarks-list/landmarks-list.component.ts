import { LandmarkService } from './../landmark.service';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Landmark } from 'src/app/models/landmark';
import { LandmarkParam } from 'src/app/models/landmarkParam';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-landmarks-list',
  templateUrl: './landmarks-list.component.html',
  styleUrls: ['./landmarks-list.component.css'],
})
export class LandmarksListComponent implements OnInit {
  @ViewChild('search') searchKeyword: ElementRef;
  landmarks: Landmark[] = [];
  landmarkParams = new LandmarkParam(1, 10);
  displayedColumns = ['name', 'address', 'pointorder', 'distance'];

  length = 0;
  pageSizeOptions: number[] = [2, 3, 5];

  constructor(private landmarkService: LandmarkService) {}

  ngOnInit(): void {
    this.loadLandmarks();
  }

  loadLandmarks() {
    this.landmarkService.getLandmarksList(this.landmarkParams).subscribe(
      (response) => {
        this.landmarks = response.data;
        this.length = response.count;
        this.landmarkParams = new LandmarkParam(
          response.pageNumber,
          response.pageSize
        );
      },
      (err) => {
        console.log(err);
      }
    );
  }

  // MatPaginator Output
  onPageChange(event: any) {
    this.landmarkParams = new LandmarkParam(event.pageIndex+1,event.pageSize);
    this.loadLandmarks();
  }

  getInfo(id: number){
    const landmark = this.landmarks.find(l => l.landmarkId == id);
    const infoString = `Address: ${landmark?.address} \n
    Latitude :${landmark?.latitude}  \n
    Longitude :${landmark?.longitude} \n
    Contact Number: ${landmark?.contactNumber} \n
    Distance: ${landmark?.distance} \n
    Created Date: ${landmark?.createdDate}`;
    return infoString;    
  }

  searchLandmark(){
    this.landmarkParams = new LandmarkParam(1,10);
    this.landmarkParams.search = this.searchKeyword.nativeElement.value;
    this.loadLandmarks();
  }
}
