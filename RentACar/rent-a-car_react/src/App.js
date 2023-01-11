import { Routes, Route } from 'react-router-dom';
import { AuthProvider } from './context/AuthContext.js';
import Footer from './components/Footer/Footer.js';
import Header from './components/Header/Header';
import Home from './pages/Home/Home.js';
import Logout from './pages/Logout/Logout.js';
import Login from './pages/Login/Login';
import Register from './pages/Register/Register';
import Catalog from './pages/Catalog/Catalog.js';
import CarDetails from './pages/CarDeatils/CarDetails.js';
import BookingForm from './components/BookingForm/BookingForm.js';
import MyBookings from './pages/MyBookings/MyBookings.js'
import Create from './pages/Create/Create.js';
import MyCars from './pages/MyCars/MyCars.js'
import ErrorPage from './pages/ErrorPage/Error.js';
import PrivateRoute from './components/Common/PrivateRoute.js';

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
            <Route path="/catalog" element={<Catalog />} />
            <Route path="/catalog/:carId" element={<CarDetails />} />
            <Route path="/my-bookings" element={(
              <PrivateRoute>
                <MyBookings />
              </PrivateRoute>)} />
            <Route path="/my-cars" element={(
              <PrivateRoute>
                <MyCars />
              </PrivateRoute>)}/>
            <Route path="/create" element={(
              <PrivateRoute>
                <Create />
              </PrivateRoute>)} />
            <Route path="/booking/:carId" element={(
              <PrivateRoute>
                <BookingForm />
              </PrivateRoute>)} />
            <Route path="/error" element={<ErrorPage />} />
          </Routes>
        </main>
        <Footer />
      </div>
    </AuthProvider>
  );
}

export default App;
