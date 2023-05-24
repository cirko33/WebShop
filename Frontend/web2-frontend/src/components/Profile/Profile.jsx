import { useEffect, useState } from "react";
import userService from "../../services/userService";
import './styles.css'
import { useNavigate } from "react-router-dom";

const Profile = () => {
  const navigate = useNavigate();
  const [data, setData] = useState({
    username: "",
    password: "",
    newPassword: "",
    email: "",
    fullName: "",
    birthday: "",
    address: "",
    image: "",
    imageFile: "",
  });

  useEffect(() => {
    userService.getUser().then(res => 
    {
      setData({...data, ...res, birthday: res.birthday.split('T')[0]});
    })
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const [errors, setErrors] = useState({});

  const handleChange = (e) => {
    const { name, value } = e.target;
    setData({ ...data, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const validationErrors = {};
    if (!data.username) {
      validationErrors.username = "Username is required";
    } else if (!/^[a-zA-Z0-9]+$/.test(data.username)) {
      validationErrors.username = "Username can only contain alphanumeric characters";
    } else if (data.username.length > 100) {
      validationErrors.username = "Username cannot exceed 100 characters";
    }

    if (data.password && data.password.length > 100) {
      validationErrors.password = "Password cannot exceed 100 characters";
    }

    if (data.newPassword && data.newPassword.length > 100) {
      validationErrors.newPassword = "New Password cannot exceed 100 characters";
    }

    if (!data.email) {
      validationErrors.email = "Email is required";
    } else if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(data.email)) {
      validationErrors.email = "Invalid email address";
    } else if (data.email.length > 100) {
      validationErrors.email = "Email cannot exceed 100 characters";
    }

    if (!data.fullName) {
      validationErrors.fullName = "Full Name is required";
    } else if (data.fullName.length > 100) {
      validationErrors.fullName = "Full Name cannot exceed 100 characters";
    }

    if (!data.birthday) {
      validationErrors.birthday = "Birthday is required";
    }

    if (!data.address) {
      validationErrors.address = "Address is required";
    } else if (data.address.length > 100) {
      validationErrors.address = "Address cannot exceed 100 characters";
    }

    setErrors(validationErrors);
    if (Object.keys(validationErrors).length !== 0) 
      return;
    
    const formData = new FormData();
    
    for(let prop in data) {
      formData.append(prop, data[prop]);
    }

    // eslint-disable-next-line no-unused-vars
    userService.setUser(formData).then(res => alert("Successfully changed!")).catch(e => { console.log(e); return; });
    navigate("/home");
  };

  return (
    <div>
      <h2>Edit Profile</h2>
      <form onSubmit={handleSubmit} >
        <div>
          <label>Username:</label>
          <input type="text" name="username" value={data.username} onChange={handleChange} />
          {errors.username && <span>{errors.username}</span>}
        </div>
        <div>
          <label>Password:</label>
          <input type="password" name="password" value={data.password} onChange={handleChange} />
          {errors.password && <span>{errors.password}</span>}
        </div>
        <div>
          <label>New Password:</label>
          <input type="password" name="newPassword" value={data.newPassword} onChange={handleChange} />
          {errors.newPassword && <span>{errors.newPassword}</span>}
        </div>
        <div>
          <label>Email:</label>
          <input type="email" name="email" value={data.email} onChange={handleChange} />
          {errors.email && <span>{errors.email}</span>}
        </div>
        <div>
          <label>Full Name:</label>
          <input type="text" name="fullName" value={data.fullName} onChange={handleChange} />
          {errors.fullName && <span>{errors.fullName}</span>}
        </div>
        <div>
          <label>Birthday:</label>
          <input type="date" name="birthday" value={data.birthday} onChange={handleChange} />
          {errors.birthday && <span>{errors.birthday}</span>}
        </div>
        <div>
          <label>Address:</label>
          <textarea name="address" value={data.address} onChange={handleChange} />
          {errors.address && <span>{errors.address}</span>}
        </div>
        <div>
          <img title="Image" width={200} height={100} alt="No image" src={data.imageFile ? URL.createObjectURL(data.imageFile) : (data.image && `data:image/jpg;base64,${data.image}`)}/>
        </div>
        <div>
          <input type="file" name="imageFile" accept="image/jpg" onChange={(e) => {console.log(e); setData({...data, imageFile: e.target.files[0]});}}/>
        </div>
        <button type="submit">Save</button>
      </form>
    </div>
  );
};

export default Profile;
