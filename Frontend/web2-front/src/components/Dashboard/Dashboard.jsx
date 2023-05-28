import { useContext } from "react";
import AuthContext from "../../contexts/auth-context";
import { Link } from "react-router-dom";
import classes from './Dashboard.module.css';
import { Button } from "@mui/material";

const Dashboard = () => {
  const context = useContext(AuthContext);

  return (
      <div className={classes.dashboard}>
          <Link to="/profile" className={classes.but}><Button variant="contained">Profile</Button></Link>
        {context.type() === 'Administrator' && (
          <>
            <Link to="/verification" className={classes.but}><Button variant="contained">Verification</Button></Link>
            <Link to="/all-orders" className={classes.but}><Button variant="contained">All orders</Button></Link>
          </>
        )}
        {context.type() === 'Seller' && (
          <>
            <Link to="/adding-products" className={classes.but}><Button variant="contained">Adding products</Button></Link>
            <Link to="/new-orders" className={classes.but}><Button variant="contained">New orders</Button></Link>
            <Link to="/my-orders" className={classes.but}><Button variant="contained">My orders</Button></Link>
          </>
        )}
        {context.type() === 'Buyer' && (
          <>
            <Link to="/new-order" className={classes.but}><Button variant="contained">New orders</Button></Link>
            <Link to="/previous-orders" className={classes.but}><Button variant="contained">Previous orders</Button></Link>
          </>
        )}
      </div>
  );
};

export default Dashboard;