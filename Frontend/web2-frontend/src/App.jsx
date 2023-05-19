import './App.css'
import Navbar from './components/Navigation/Navbar';
import Router from './router/Router';



const App = () => {
  return (
    <>
      <Navbar />
      <div className="container">
        <Router />
      </div>
    </>
  )
}

export default App
