import './App.css'
import Navbar from './components/Navbar/Navbar';
import Router from './router/Router';



const App = () => {
  return (
    <>
      <Navbar />
      <div className="container">
        <div className="overlay">
          <div className="content">
            <Router />
          </div>
        </div>
      </div>
    </>
  )
}

export default App
