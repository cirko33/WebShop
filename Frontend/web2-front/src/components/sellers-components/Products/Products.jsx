import { useEffect, useState } from "react";
import ProductsR from "../../../reusable/Product/ProductsR";
import sellerService from "../../../services/sellerService";

const Products = () => {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    sellerService.getProducts().then((res) => {setProducts(res.products); console.log(res.products)});
  }, []);

  return (
    <>
      <ProductsR title="My products" products={products} />
    </>
  );
};

export default Products;
