import { Card, CardContent, Typography } from "@mui/material";
import Item from "./Item";
import { dateTimeToString } from "../../helpers/helpers";

const Orders = ({ orders, title }) => {
  const status = (o) => {
    return new Date(o.deliveryTime) > new Date() ? "In delivery" : "Delivered"
  }

  const calculateTotal = (items) => {
    let total = 0;
    items.forEach(e => {
      total += (e.amount * e.product.price);
    });
    return total;
  }
  return (
    <div>
      <Typography variant="h4">{title}</Typography>
      {orders &&
        orders.map((o, index) => (
          <Card key={index} sx={{ minWidth: 300, background: "gray", color: "white" }}>
            <CardContent>
              <Typography>Order ID: {o.id}</Typography>
              <Typography>Ordered: {dateTimeToString(o.orderTime)}</Typography>
              <Typography>Delivery: {dateTimeToString(o.deliveryTime)}</Typography>
              <Typography>Address: {o.deliveryAddress}</Typography>
              <Typography>Status: {status(o)}</Typography>
              <Typography sx={{ fontWeight: "bold"}}>
                Items:
              </Typography>
              {o.items.map((item, index) => (
                <Item key={index} item={item} />
              ))}
              <hr/>
              <Typography>Comment: {o.comment}</Typography>
              <Typography>Total: {calculateTotal(o.items)}</Typography>
            </CardContent>
          </Card>
        ))}
        {orders.length === 0 && <Typography variant="h5" sx={{color:"blue"}}>There are no orders</Typography>}
    </div>
  );
};

export default Orders;
