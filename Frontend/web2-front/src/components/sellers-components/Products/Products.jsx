import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import sellerService from "../../../services/sellerService";
import classes from "./Products.module.css";
import ProductUpdateForm from "./ProductUpdateForm";
import ProductAddForm from "./ProductAddForm";
import { convertImage } from "../../../helpers/helpers";

const Products = () => {
  const [products, setProducts] = useState([]);
  const updateProducts = () => sellerService.getProducts().then((res) => setProducts(res));
  const [open, setOpen] = useState(false);
  const [data, setData] = useState({});

  useEffect(() => {
    updateProducts();
  }, []);

  return (
    <div>
      <Typography variant="h4">My products</Typography>
      <div className={classes.cardContainer}>
        <ProductUpdateForm
          open={open}
          setOpen={setOpen}
          data={data}
          setData={setData}
          updateProducts={updateProducts}
        />
        <ProductAddForm updateProducts={updateProducts} />
        {products &&
          products.length > 0 &&
          products.map((p, index) => (
            <Card className={classes.card} sx={{ color: "white", background: "#0c1215" }} key={index}>
              <CardMedia
                component="img"
                alt="No pic"
                sx={{ height: 150, width: "100%", objectFit: "contain" }}
                image={p.image && convertImage(p.image)}
              />
              <CardContent>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Product ID: {p.id}</Typography>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Name: {p.name}</Typography>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Price: {p.price}</Typography>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Amount: {p.amount}</Typography>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Description: {p.description}</Typography>
              </CardContent>
              <CardActions>
                <Button
                  size="small"
                  sx={{ fontWeight: "bold" }}
                  color="success"
                  onClick={(e) => {
                    setData({ ...p, imageFile: "" });
                    setOpen(true);
                  }}
                >
                  Edit
                </Button>
                <Button
                  size="small"
                  sx={{ fontWeight: "bold" }}
                  color="error"
                  onClick={(e) => sellerService.deleteProduct(p.id).then((res) => res && updateProducts())}
                >
                  Delete
                </Button>
              </CardActions>
            </Card>
          ))}
      </div>
    </div>
  );
};

export default Products;
