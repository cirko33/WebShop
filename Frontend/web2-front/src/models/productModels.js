export class CreateProductModel {
  constructor(name, price, amount, description, image, imageFile) {
    this.name = name;
    this.price = price;
    this.amount = amount;
    this.description = description;
    this.image = image;
    this.imageFile = imageFile;
  }
}

export class ProductModel extends CreateProductModel {
  constructor(name, price, amount, description, image, imageFile, id) {
    super(name, price, amount, description, image, imageFile);
    this.id = id;
  }
}
