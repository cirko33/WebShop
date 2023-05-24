import { useContext } from "react";
import AuthContext from "../../contexts/auth-context";
import { Link } from "react-router-dom";
import './styles.css'

const Dashboard = () => {
    const context = useContext(AuthContext);

    return ( 
        <div className="dashboard">
            <div>
                <Link to="/profile">Profile</Link>
            </div>
            { context.type() === "Administrator" &&
                <div className="admin-links">
                    <div>
                        <Link to="/verification">Verification</Link>
                    </div>
                    <div>
                        <Link to="/all-orders">All orders</Link>
                    </div>
                </div>
            }
            { context.type() === "Seller" &&
                <div className="seller-links">
                    <div>
                        <Link to="/adding-products">Adding products</Link>
                    </div>
                    <div>
                        <Link to="/new-orders">New orders</Link>
                    </div>
                    <div>
                        <Link to="/my-orders">My orders</Link>
                    </div>
                </div>
            }
            { context.type() === "Buyer" &&
                <div className="buyer-links">
                    <div>
                        <Link to="/new-order">New orders</Link>
                    </div>
                    <div>
                        <Link to="/previous-orders">Previous orders</Link>
                    </div>
                </div>
            }
        </div> 
    );
}
 
export default Dashboard;