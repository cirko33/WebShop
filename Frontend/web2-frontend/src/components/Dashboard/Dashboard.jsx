import { useContext } from "react";
import AuthContext from "../../contexts/auth-context";

const Dashboard = () => {
    const context = useContext(AuthContext);

    return ( 
        <>
            <p>BOG S TOBOM {context.type()}</p>
        </> 
    );
}
 
export default Dashboard;