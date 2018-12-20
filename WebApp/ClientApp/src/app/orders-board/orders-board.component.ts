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
		var tab = M.Tabs.init(document.querySelector('.tabs'), {});
		var collapsables = M.Collapsible.init(document.querySelectorAll('.collapsible'), {});
	}

	getOrders() {
		this.service.getOrders(this.filter).subscribe(
			data => { this.orders = data; },
			err => console.log(err)
		);
	}
}
