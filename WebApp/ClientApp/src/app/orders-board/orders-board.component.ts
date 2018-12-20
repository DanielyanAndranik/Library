import { Component, OnInit } from '@angular/core';
import { OrdersService, OrdersFilter } from '../services/OrdersService/orders.service';

@Component({
	selector: 'app-orders-board',
	providers: [OrdersService],
	templateUrl: './orders-board.component.html',
	styleUrls: ['./orders-board.component.css']
})
export class OrdersBoardComponent implements OnInit {

	filter: OrdersFilter;
	orders: Object;

	constructor(private service: OrdersService) {
		this.filter = new OrdersFilter();
	}

	ngOnInit() {
	}

	getOrders() {
		this.service.getOrders(this.filter).subscribe(
			data => { this.orders = data; },
			err => console.log(err)
		);
	}
}
