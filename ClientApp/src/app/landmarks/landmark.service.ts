import { PagedResult } from './../models/pagedResult';
import { Landmark } from './../models/landmark';
import { LandmarkParam } from '../models/landmarkParam';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LandmarkService {

  private baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getLandmarksList(landmarkParams: LandmarkParam){

    let params = new HttpParams();
    if(landmarkParams.search){
      params = params.append('search',landmarkParams.search);
    }      
    params = params.append('pageNumber',landmarkParams.pageNumber);
    params = params.append('pageSize',landmarkParams.pageSize);

    return this.http.get<PagedResult>(this.baseUrl + 'landmarks',{params: params})
  }

  saveLandmark(value: any){
    return this.http.post(this.baseUrl +'landmarks',value);
  }
}
