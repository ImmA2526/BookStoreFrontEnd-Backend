<template>
  <div>
    <div class="card">
      <div id="heading">
        Customer Details
        <div id="edit" type="button">Edit</div>
      </div>
      <div class="row">
        <div class="col">
          <input
            type="text"
            id="name"
            class="form-control"
            placeholder="Name"
            v-model="form.name"
          />
        </div>
        <div class="col">
          <input
            type="text"
            id="phone"
            class="form-control"
            placeholder="Phone Number"
            v-model="form.phone"
          />
        </div>
      </div>

      <div class="row">
        <div class="col">
          <input
            type="text"
            id="pin"
            class="form-control"
            placeholder="Pincode"
            v-model="form.pin"
          />
        </div>
        <div class="col">
          <input
            type="text"
            id="local"
            class="form-control"
            placeholder="Locality"
            v-model="form.local"
          />
        </div>
      </div>
      <div class="row">
        <div class="col">
          <input
            type="text"
            id="address"
            class="form-control"
            placeholder="Address"
            v-model="form.address"
          />
        </div>
      </div>
      <div class="row">
        <div class="col">
          <input
            type="text"
            id="city"
            class="form-control"
            placeholder="City/Town"
            v-model="form.city"
          />
        </div>
        <div class="col">
          <input
            type="text"
            class="form-control"
            id="landmark"
            placeholder="Landmark"
            v-model="form.landmark"
          />
        </div>
      </div>
      <div id="type">Type</div>
      <div id="mainRadio">
        <div class="form-check form-check-inline">
          <input
            class="home"
            type="radio"
            name="home"
            id="addresstype"
            value="Home"
            v-model="form.addresstype"
          />
          <label class="form-check-label" id="homes">Home</label>
        </div>
        <div class="form-check form-check-inline">
          <input
            class="work"
            type="radio"
            name="work"
            v-model="form.addresstype"
            value="Work"
          />
          <label class="form-check-label" id="works">Work</label>
        </div>

        <div class="form-check form-check-inline">
          <input
            type="radio"
            class="other"
            name="other"
            id="addresstype"
            value="other"
            v-model="form.addresstype"
          />
          <label class="form-check-label" id="others">Other</label>
        </div>
      </div>
<div v-if="!display">
      <b-button id="button" variant="primary" @click="addCustomer();display = !display"
        >CONTINUE</b-button
      >
</div>
     </div>
     <div id="blank"></div>
    <div id="maincard" v-if="display"><Order /></div>
  </div>
</template>

<script>
import bookService from "../Services/bookService";
import Order from "../components/Order";
export default {
  components: {
    Order,
  },
  // name: "DisplayBooks",
  // props: ["allBooks", "total"],

  data() {
    return {
      display: false,
      form: {
        name: null,
        phone: null,
        pin: null,
        local: null,
        city: null,
        address: null,
        addressType: null,
      },
    };
  },

  methods: {
    addCustomer() {
      console.log(localStorage.getItem("UserId"));
      const bookData = {
        fullName: this.form.name,
        phoneNumber: this.form.phone,
        pinCode: this.form.pin,
        locality: this.form.local,
        city: this.form.city,
        address: this.form.address,
        addressType: this.form.addresstype,
        UserId: localStorage.getItem("UserId"),
      };
      console.log(bookData);
      bookService
        .AddCustomer(bookData)
        .then((response) => {
          alert(" Customer Added Succesfully... ");
          this.display=!this.display;
          console.log(response);
          
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
</script>

<style lang="scss" scoped>
#address {
  height: 80px;
}

#button {
  // margin-bottom: 10px;
  width: 140px;
  height: 29px;
  background: #3371b5 0% 0% no-repeat padding-box;
  border-radius: 2px;
  opacity: 1;
  font-size: 12px;
  text-align: center;
  margin-left: 580px;
  margin-top: -14px;
}

//Main Cardd Container 
.card {
  position: relative;
  flex-direction: column;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: 420px;
  top: 112px;
 left: 240px;
  width: 774px;
}

.card-body {
  flex: 1 1 auto;
  min-height: 1px;
}

input[type="text"] {
  padding: 10px 23px;
  margin: 6px 0;
  width: 300px;
  height: 36px;
  outline: 1px solid lightgrey;
}
#name,
#pin,
#city {
  margin-left: 58px;
}
#phone,
#local,
#landmark {
  margin-left: -20px;
}

#address {
  margin-left: 58px;
  width: 622px;
}

.work,
.other {
  margin-left: 40px;
  font-size: small;
}

#homes,
#works,
#others {
  width: 50%;
  border: none;
  margin: 28px;
  display: flex;
  margin-left: 6px;
}

#mainRadio {
  float: left;
  border: none;
  margin-left: 1px;
}

.form-check-inline {
  display: inline-flex;
  align-items: center;
  padding-left: 0;
  margin-right: 6.75rem;
}
#type {
  margin-left: -620px;
}

#heading {
  text-align: left;
  margin-left: 20px;
  font-size: 18px;
  margin-bottom: 10px;
}

#edit {
  text-align: right;
  font-size: 18px;
  margin-bottom: 10px;
  display: inline-flex;
  margin-left: 68%;
}

#card {
  position: relative;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: 60px;
  top: 56px;
  width: 774px;
}

#lbl {
  margin-top: 16px;
}

#blank
{
  margin-top: 20px;
}

//Other Device
@media (min-width: 360px) and(max-width:640px) {
  // Card
.card {
  position: relative;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: auto;
  top: 110px;
  left: 40px;
  width: 274px;
}
//Second Card 
#space
{
  margin-top: 14px;
}
#card {
  position: relative;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: 60px;
  top: 130px;
  left: 40px;
  width: 274px;
  // min-width: 0;
}

//Button
#button {
  margin-bottom: 10px;
  width: 100px;
  height: 29px;
  background: #3371b5 0% 0% no-repeat padding-box;
  border-radius: 2px;
  opacity: 1;
  margin-top: 8px;
  font-size: 10px;
  text-align: center;
  margin-left: 80px;
}


input[type="text"] {
  padding: 4px 2px;
  font-size: 10px;
  margin: 6px 0;
  width: 110px;
  height: 34px;
  outline: 1px solid lightgrey;
}
#name,
#pin,
#city {
  margin-left: 28px;
}
#phone,
#local,
#landmark {
  margin-left: -16px;
}

#address {
  margin-left: 28px;
  width: 232px;
}

.work,
.other {
  margin-left: -50px;
  font-size: small;
}

#homes,
#works,
#others {
  width: 8px;
  border: none;
  margin: 12px;
  display: flex;
  margin-left: 2px;
}

#mainRadio {
  float: left;
  border: none;
  display: flex;
  margin-left: 6px;
}

#type {
  margin-left: -220px;
}

#heading {
  text-align: left;
  margin-left: 24px;
  font-size: 14px;
  margin-bottom: 10px;
}

#edit {
  text-align: right;
  font-size: 14px;
  margin-bottom: 10px;
  display: inline-flex;
  margin-left: 88px;
}

}
</style>