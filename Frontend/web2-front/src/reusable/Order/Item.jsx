import { Typography } from "@mui/material";

const Item = ({item}) => {
  return (
    <>
      <hr/>
      <Typography sx={{fontSize: 14}}>Name: {item.product.name}</Typography>
      <Typography sx={{fontSize: 14}}>No: {item.amount}</Typography>
      <Typography sx={{fontSize: 14}}>Price: {item.product.price}</Typography>
      <Typography sx={{fontSize: 14}}>Description: {item.product.description}</Typography>
    </>
  );
};

export default Item;
