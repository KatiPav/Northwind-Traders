import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
import Customers from './Components/Customers'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    <div id="title">Northwind Traders</div>
    <Customers/></>
  )
}

export default App
