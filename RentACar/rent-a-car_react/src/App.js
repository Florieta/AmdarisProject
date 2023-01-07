import { Routes, Route } from 'react-router-dom';

import { AuthProvider } from './context/AuthContext.js';

import Header from './components/Header/Header';
import Home from './pages/Home/Home.js';
import Logout from './pages/Logout/Logout.js';
import Login from './pages/Login/Login';
import Register from './pages/Register/Register';
import Catalog from './pages/Catalog/Catalog.js';
import CarDetails from './pages/CarDeatils/CarDetails.js';
import BookingForm from './components/BookingForm/BookingForm.js';
import MyBookings from './pages/MyBookings/MyBookings.js'
import Create from './components/Create/Create.js';
import MyCars from './pages/MyCars/MyCars.js'
import './App.css';

function App() {
  
  return (
    <AuthProvider>
    <div id="box">
      <Header />
      <main id="main-content">
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/logout" element={<Logout />} />
        <Route path="/register" element={<Register />} />
        <Route path="/my-bookings" element={<MyBookings />} />
        <Route path="/my-cars" element={<MyCars />} />
        <Route path="/create" element={<Create />} />
        <Route path="/catalog" element={<Catalog />} />
        <Route path="/catalog/:carId" element={<CarDetails />} />
        <Route path="/booking/:carId" element={<BookingForm />} />
      </Routes>
      </main>
     
    </div>
    </AuthProvider>
  );
}

export default App;
