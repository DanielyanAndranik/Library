import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class OrdersService {
	filter: OrdersFilter;

	constructor(private http: HttpClient)
	{ }

	getOrders(filter: OrdersFilter) {
		return this.http.get("../../../assets/data/orders.json", {});
	}

}
export class OrdersFilter {
	public customer: string;
	public status: string;
}
