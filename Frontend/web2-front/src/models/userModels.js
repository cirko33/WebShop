export class LoginModel {
  constructor(email, password) {
    this.email = email;
    this.password = password;
  }
}

export class EditProfileModel {
  constructor(username, password, newPassword, email, fullName, birthday, address, image, imageFile) {
    this.username = username;
    this.password = password;
    this.newPassword = newPassword;
    this.email = email;
    this.fullName = fullName;
    this.birthday = birthday;
    this.address = address;
    this.image = image;
    this.imageFile = imageFile;
  }
}

export class RegisterModel {
  constructor(username, password, email, fullName, birthday, address, type, imageFile) {
    this.username = username;
    this.password = password;
    this.email = email;
    this.fullName = fullName;
    this.birthday = birthday;
    this.address = address;
    this.type = type;
    this.imageFile = imageFile;
  }
}

export class UserModel {
  constructor(id, username, email, fullName, birthday, address, type, image) {
    this.id = id;
    this.username = username;
    this.email = email;
    this.fullName = fullName;
    this.birthday = birthday;
    this.address = address;
    this.type = type;
    this.image = image;
  }
}

export class VerifyModel {
  constructor(id, verificationStatus) {
    this.id = id;
    this.verificationStatus = verificationStatus;
  }
}
