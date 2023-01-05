import { Routes, Route } from 'react-router-dom';
import { useState, useEffect } from 'react';

import { AuthProvider } from './context/AuthContext.js';
import * as carService from './services/carService.js';

import Header from './components/Header/Header';
import Home from './components/Home/Home';
import Logout from './components/Logout/Logout.js';
import Login from './components/Login/Login';
import Register from './components/Register/Register';
import Catalog from './components/Catalog/Catalog.js';
import CarDetails from './components/CarDeatils/CarDetails.js';
import BookingForm from './components/BookingForm/BookingForm.js';
import MyBookings from './components/MyBookings/MyBookings.js'
import Create from './components/Create/Create.js';
import './App.css';

function App() {
  const [cars, setCars] = useState([]);

    useEffect(() => {
        carService.getAll()
            .then(result => {
                setCars(result)
                console.log(result)
            });
    }, []);

  return (
    <AuthProvider>
    <div id="box">
      <Header />
      <main id="main-content">
      <Routes>
        <Route path="/" element={<Home cars={cars}/>} />
        <Route path="/login" element={<Login />} />
        <Route path="/logout" element={<Logout />} />
        <Route path="/register" element={<Register />} />
        <Route path="/my-bookings" element={<MyBookings />} />
        <Route path="/create" element={<Create />} />
        <Route path="/catalog" element={<Catalog cars={cars}/>} />
        <Route path="/catalog/:carId" element={<CarDetails cars={cars}/>} />
        <Route path="/booking/:carId" element={<BookingForm cars={cars}/>} />
      </Routes>
      </main>
     
    </div>
    </AuthProvider>
  );
}

export default App;
