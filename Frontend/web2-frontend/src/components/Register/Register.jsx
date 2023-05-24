import { useState } from 'react';
import userService from '../../services/userService';
import "./styles.css"
import { useNavigate } from 'react-router-dom';

const Register = () => {
  const navigate = useNavigate();
  const [data, setData] = useState({
    username: '',
    password: '',
    email: '',
    fullName: '',
    birthday: '',
    address: '',
    type: '',
    imageFile: ''
  });

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    setData({
      ...data,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const validationErrors = {};

    if (!data.username) {
      validationErrors.username = 'Username is required';
    } else if (!/^[a-zA-Z0-9]+$/.test(data.username)) {
      validationErrors.username = 'Username can only contain alphanumeric characters';
    } else if (data.username.length > 100) {
      validationErrors.username = 'Username cannot exceed 100 characters';
    }

    if (!data.password) {
      validationErrors.password = 'Password is required';
    } else if (data.password.length > 100) {
      validationErrors.password = 'Password cannot exceed 100 characters';
    }

    if (!data.email) {
      validationErrors.email = 'Email is required';
    } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(data.email)) {
      validationErrors.email = 'Invalid email address';
    } else if (data.email.length > 100) {
      validationErrors.email = 'Email cannot exceed 100 characters';
    }
    
    if (!data.fullName) {
      validationErrors.fullName = 'Full Name is required';
    } else if (data.fullName.length > 100) {
      validationErrors.fullName = 'Full Name cannot exceed 100 characters';
    }
    
    if (!data.birthday) {
      validationErrors.birthday = 'Birthday is required';
    }
   
    if (!data.address) {
      validationErrors.address = 'Address is required';
    } else if (data.address.length > 200) {
      validationErrors.address = 'Address cannot exceed 200 characters';
    }
    
    if (!data.type) {
      validationErrors.type = 'User Type is required';
    } else if (data.type != 1 || data.type != 2) {
      validationErrors.type = 'Type can be only seller or buyer';
    }

    setErrors(validationErrors);

    // If there are no validation errors, submit the form
    if (Object.keys(validationErrors).length !== 0) {
      return;
    }

    const formData = new FormData();
    for(let prop in data) {
      formData.append(prop, data[prop]);
    }

    // eslint-disable-next-line no-unused-vars
    userService.register(formData).then(res => alert("Successfully registered!")).catch(e => { console.log(e); return; });
    navigate("/");
  };

  return (
    <div>
      <h2>Registration</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Username:</label>
          <input
            type="text"
            name="username"
            value={data.username}
            onChange={handleChange}
          />
          {errors.username && <span>{errors.username}</span>}
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            name="password"
            value={data.password}
            onChange={handleChange}
          />
          {errors.password && <span>{errors.password}</span>}
        </div>
        <div>
          <label>Email:</label>
          <input
            type="email"
            name="email"
            value={data.email}
            onChange={handleChange}
          />
          {errors.email && <span>{errors.email}</span>}
        </div>
        <div>
          <label>Full Name:</label>
          <input
            type="text"
            name="fullName"
            value={data.fullName}
            onChange={handleChange}
          />
          {errors.fullName && <span>{errors.fullName}</span>}
        </div>
        <div>
          <label>Birthday:</label>
          <input
            type="date"
            name="birthday"
            value={data.birthday}
            onChange={handleChange}
          />
          {errors.birthday && <span>{errors.birthday}</span>}
        </div>
        <div>
          <label>Address:</label>
          <textarea
            name="address"
            value={data.address}
            onChange={handleChange}
          />
          {errors.address && <span>{errors.address}</span>}
        </div>
        <div>
          <label>User Type:</label>
          <select
            name="type"
            value={data.type}
            onChange={handleChange}
          >
            <option value="">Select a type</option>
            <option value="1">Seller</option>
            <option value="2">Buyer</option>
          </select>
          {errors.type && <span>{errors.type}</span>}
        </div>
        <div>
          <img title="Image" width={200} height={100} alt="No image" src={data.imageFile && URL.createObjectURL(data.imageFile)}/>
        </div>
        <div>
          <input type="file" name="imageFile" accept="image/jpg" onChange={(e) => {console.log(e); setData({...data, imageFile: e.target.files[0]});}}/>
        </div>
        <button type="submit">Register</button>
      </form>
    </div>
  );
};

export default Register;