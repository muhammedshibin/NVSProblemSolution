export class LandmarkParam
{
    /**
     *
     */
    constructor(pageNumber: number,pageSize: number) {
       
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
    }
    search = '';
    pageNumber: number;
    pageSize: number;
}