import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

	@Input() type: string;
	public orders: Order[];

	constructor() {
		this.orders = [];
	}

	ngOnInit() {
		
	}
	ServiceOnButtonClick() {
		console.log(this.type);
		this.orders.push(new Order('1', 'Harry Potter'));
		this.orders.push(new Order('2', 'Harry Potter'));
	}
}

export class Order {
	public Id: string;
	public Title: string;
	constructor(Id:string, Title:string)
	{
		this.Id = Id;
		this.Title = Title;
	}
}
