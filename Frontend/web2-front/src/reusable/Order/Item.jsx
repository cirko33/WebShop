import { Typography } from "@mui/material";

const Item = ({item}) => {
  return (
    <>
      <hr/>
      <Typography sx={{fontSize: 14, color:"lightblue"}}>Name: {item.name}</Typography>
      <Typography sx={{fontSize: 14, color:"lightblue"}}>No: {item.amount}</Typography>
      <Typography sx={{fontSize: 14, color:"lightblue"}}>Price: {item.price}</Typography>
    </>
  );
};

export default Item;
