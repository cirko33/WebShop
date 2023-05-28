export class CreateItemModel {
  constructor(amount, productId) {
    this.amount = amount;
    this.productId = productId;
  }
}

export class ItemModel extends CreateItemModel {
  constructor(amount, productId, product) {
    super(amount, productId);
    this.product = product;
  }
}
