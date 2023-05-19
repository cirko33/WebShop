import { useState } from 'react';
import "./styles.css"

const Register = () => {
  const [formData, setFormData] = useState({
    username: '',
    password: '',
    email: '',
    fullName: '',
    birthday: '',
    address: '',
    type: ''
  });

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const validationErrors = {};

    if (!formData.username) {
      validationErrors.username = 'Username is required';
    } else if (!/^[a-zA-Z0-9]+$/.test(formData.username)) {
      validationErrors.username = 'Username can only contain alphanumeric characters';
    } else if (formData.username.length > 100) {
      validationErrors.username = 'Username cannot exceed 100 characters';
    }

    if (!formData.password) {
      validationErrors.password = 'Password is required';
    } else if (formData.password.length > 100) {
      validationErrors.password = 'Password cannot exceed 100 characters';
    }

    if (!formData.email) {
      validationErrors.email = 'Email is required';
    } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(formData.email)) {
      validationErrors.email = 'Invalid email address';
    } else if (formData.email.length > 100) {
      validationErrors.email = 'Email cannot exceed 100 characters';
    }
    
    if (!formData.fullName) {
      validationErrors.fullName = 'Full Name is required';
    } else if (formData.fullName.length > 100) {
      validationErrors.fullName = 'Full Name cannot exceed 100 characters';
    }
    
    if (!formData.birthday) {
      validationErrors.birthday = 'Birthday is required';
    }
   
    if (!formData.address) {
      validationErrors.address = 'Address is required';
    } else if (formData.address.length > 200) {
      validationErrors.address = 'Address cannot exceed 200 characters';
    }
    
    if (!formData.type) {
      validationErrors.type = 'User Type is required';
    }

    setErrors(validationErrors);

    // If there are no validation errors, submit the form
    if (Object.keys(validationErrors).length === 0) {
      console.log('Form submitted successfully');
    }


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
            value={formData.username}
            onChange={handleChange}
          />
          {errors.username && <span>{errors.username}</span>}
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
          />
          {errors.password && <span>{errors.password}</span>}
        </div>
        <div>
          <label>Email:</label>
          <input
            type="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
          />
          {errors.email && <span>{errors.email}</span>}
        </div>
        <div>
          <label>Full Name:</label>
          <input
            type="text"
            name="fullName"
            value={formData.fullName}
            onChange={handleChange}
          />
          {errors.fullName && <span>{errors.fullName}</span>}
        </div>
        <div>
          <label>Birthday:</label>
          <input
            type="date"
            name="birthday"
            value={formData.birthday}
            onChange={handleChange}
          />
          {errors.birthday && <span>{errors.birthday}</span>}
        </div>
        <div>
          <label>Address:</label>
          <textarea
            name="address"
            value={formData.address}
            onChange={handleChange}
          />
          {errors.address && <span>{errors.address}</span>}
        </div>
        <div>
          <label>User Type:</label>
          <select
            name="type"
            value={formData.type}
            onChange={handleChange}
          >
            <option value="">Select a type</option>
            <option value="1">Seller</option>
            <option value="2">Buyer</option>
          </select>
          {errors.type && <span>{errors.type}</span>}
        </div>
        <button type="submit">Register</button>
      </form>
    </div>
  );
};

export default Register;