export class CreateOrderModel {
  constructor(deliveryAddress, comment, items) {
    this.deliveryAddress = deliveryAddress;
    this.comment = comment;
    this.items = items;
  }
}

export class OrderModel {
  constructor(id, deliveryAddress, comment, orderTime, deliveryTime, isCancelled, items) {
    this.id = id;
    this.deliveryAddress = deliveryAddress;
    this.comment = comment;
    this.orderTime = orderTime;
    this.deliveryTime = deliveryTime;
    this.isCancelled = isCancelled;
    this.items = items;
  }
}
