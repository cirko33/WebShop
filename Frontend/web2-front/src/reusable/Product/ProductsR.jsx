import { Card, CardContent, CardMedia, Typography } from "@mui/material";
import {convertImage, dateTimeToString, } from '../../helpers/helpers'

const ProductsR = ({ products, title }) => {
    return ( <div>
      <Typography variant="h4">{title}</Typography>
      {products &&
        products.map((p, index) => (
          <Card key={index} sx={{ minWidth: 300, background: "gray", color: "white" }}>
            <CardMedia 
                    component="img"
                    alt="No pic"
                    height="150"
                    image={p.image && convertImage(p.image)}
            />
            <CardContent>
              <Typography>Product ID: {p.id}</Typography>
              <Typography>Ordered: {dateTimeToString(p.orderTime)}</Typography>
              <Typography>Delivery: {dateTimeToString(p.deliveryTime)}</Typography>
              <Typography>Address: {p.deliveryAddress}</Typography>
              <Typography sx={{ fontWeight: "bold"}}>
                Items:
              </Typography>
              <hr/>
            </CardContent>
          </Card>
        ))}
        {products.length === 0 && <Typography variant="h5" sx={{color:"blue"}}>There are no products</Typography>}
    </div> );
}
 
export default ProductsR;