import { Landmark } from './landmark';
export interface PagedResult {
    count: number;
    data: Landmark[];
    pageNumber: number;
    pageSize: number;
}