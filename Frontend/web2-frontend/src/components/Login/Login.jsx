import { useContext, useState } from "react";
import { Link } from "react-router-dom";
import AuthContext from "../../contexts/auth-context";
import "./styles.css"

const Login = () => {
    const [loginForm, setLoginForm] = useState({});
    const context = useContext(AuthContext);

    const handleSubmit = async (e) => {
        e.preventDefault();

        if(!loginForm.email || !loginForm.password) {
            alert("All fields required.")
            return;
        }

        await context.onLogin(loginForm);
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div>
                <label>Email:</label>
                <input
                    type="email"
                    id="email"
                    value={loginForm.email}
                    onChange={e => setLoginForm({...loginForm, email: e.target.value})}
                    required
                />
                </div>
                <div>
                <label>Password:</label>
                <input
                    type="password"
                    id="password"
                    value={loginForm.password}
                    onChange={e => setLoginForm({...loginForm, password: e.target.value})}
                    required
                />
                </div>
                <button type="submit">Login</button>
            </form>
            <p>
                {"You don't have account? "}
                <Link to={"/register"}>Register</Link>
            </p>
        </div>
    )
}

export default Login;