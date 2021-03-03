<template>
  <div>
    <form>
      <b-card>
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
        <b-button
          id="button"
          style="margin-top: 5%; float:right; position: relative"
          variant="primary"
          v-on:click="addCustomer()"
          >CONTINUE</b-button
        >
      </b-card>
    </form>
  </div>
</template>

<script>
import bookService from "../Services/bookService";
export default {
  // name: "DisplayBooks",
  // props: ["allBooks", "total"],

  data() {
    return {
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
          console.log(response);
          alert(" Success ");
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
  float: right;
  position: relative;
  font-size: 14px;
  height: 30px;
  margin-right: 20px;
}

.card {
  position: relative;
  flex-direction: column;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: 420px;
  top: 112px;
  left: 177px;
  width: 774px;
}

.card-body {
  flex: 1 1 auto;
  min-height: 1px;
 }

input[type="text"] {
  padding: 10px 20px;
  margin: 10px 0;
  width: 80%;
  height: 40px;
  outline: 1px solid lightgrey;
}
#name,
#pin,
#city {
  margin-left: 20px;
}
#phone,
#local,
#landmark {
  margin-left: -60px;
}

#address {
  margin-left: 20px;
  width: 580px;
}

.work,
.other {
  margin-left: 60px;
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

#type {
  float: left;
  margin-left: 20px;
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
</style>
