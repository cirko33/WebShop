import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import buyerService from "../../../services/buyerService";
import classes from "./NewOrder.module.css";
import { convertImage } from "../../../helpers/helpers";
import ConfirmDialog from "./ConfirmDialog";

const NewOrder = () => {
  const [products, setProducts] = useState([]);
  const [cartEmpty, setCartEmpty] = useState(true);
  const [open, setOpen] = useState(false);
  const [confirmed, setConfirmed] = useState(false);
  const updateProducts = () =>
    buyerService.getProducts().then((res) => {
      setProducts(res);
    });
  const [cart, setCart] = useState({});

  useEffect(() => {
    let empty = true;
    for (const i in cart) {
      if (cart[i] !== 0) {
        empty = false;
        break;
      }
    }
    setCartEmpty(empty);
  }, [cart]);

  useEffect(() => {
    if(confirmed) {
      buyerService.postOrder()
    }
  },[confirmed])

  useEffect(() => {
    updateProducts();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const changeValue = (id, value, maxAmount) => {
    if (value < 0) value = 0;
    else if (value > maxAmount) value = cart[id];

    setCart({
      ...cart,
      [id]: value,
    });
  };

  return (
    <div>
      <Typography variant="h4">Buy or bye</Typography>
      <div className={classes.cardContainer}>
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
              {cart[p.id] === undefined && setCart({ ...cart, [p.id]: 0 })}
              <CardContent>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Product ID: {p.id}</Typography>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Name: {p.name}</Typography>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Price: {p.price}</Typography>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Amount: {p.amount}</Typography>
                <Typography sx={{ fontSize: 14, flexWrap: "wrap" }}>Description: {p.description}</Typography>
              </CardContent>
              <CardActions>
                <Button
                  variant="contained"
                  className={classes.button}
                  onClick={(e) => changeValue(p.id, cart[[p.id]] - 1, p.amount)}
                >
                  {"<"}
                </Button>
                <input
                  className={classes.numb}
                  pattern="[0-9]{0,4}"
                  value={cart[[p.id]]}
                  onChange={(e) => changeValue(p.id, e.target.value, p.amount)}
                />
                <Button
                  className={classes.button}
                  variant="contained"
                  onClick={(e) => changeValue(p.id, cart[[p.id]] + 1, p.amount)}
                >
                  {">"}
                </Button>
              </CardActions>
            </Card>
          ))}
      </div>
      {!cartEmpty && (
        <Button className={classes.buyButton} variant="contained">
          Buy
        </Button>
      )}
    </div>
  );
};

export default NewOrder;
