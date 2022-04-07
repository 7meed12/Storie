import { IProduct } from "./products";

export default interface IPagination {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IProduct[];

}
