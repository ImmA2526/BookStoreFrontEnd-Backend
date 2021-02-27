<template>
  <div class="md-layout">
    <form id="md-card" novalidate @submit.prevent="validateUser">
      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <center>
          <div class="h2" id="namess">
            <md-button to="./" id="txt" class="md-primary" :disabled="sending"
              >Login</md-button
            >
            <md-button
              to="./Register"
              id="txts"
              class="md-primary"
              :disabled="sending"
              >SignUp</md-button
            >
          </div>
        </center>

        <div class="form-group row">
          <label id="fname" class="col-sm-2 col-form-label">Full Name</label>
          <div class="col-sm-8">
            <input
              type="text"
              id="name"
              name="fullname"
              v-model="form.fullname"
            />
          </div>
        </div>

        <div class="form-group row">
          <label class="col-sm-2 col-form-label">Email Id</label>
          <div class="col-sm-8">
            <input type="email" id="email" name="email" v-model="form.email" />
          </div>
        </div>

        <div class="form-group row">
          <label class="col-sm-2 col-form-label">Password</label>
          <div class="col-sm-8">
            <input
              type="password"
              id="pass"
              name="password"
              v-model="form.password"
            />
          </div>
        </div>

        <div class="form-group row">
          <label class="col-sm-2 col-form-label">Phone Number</label>
          <div class="col-sm-8">
            <input type="text" id="phone" name="phone" v-model="form.phone" />
          </div>
        </div>

        <md-progress-bar md-mode="indeterminate" v-if="sending" />

        <md-card-actions>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-120">
              <md-button
                v-on:click="registerPost()"
                type="submit"
                id="txt1"
                class="md-dense md-raised md-primary"
                :disabled="sending"
                >SignUp</md-button
              >
            </div>
          </div>
        </md-card-actions>
        <!-- <div class="blank"></div> -->
      </md-card>
      <!-- <md-snackbar :md-active.sync="userSaved"
        >The user {{ loginUser }} successfully login!</md-snackbar
      > -->
    </form>
  </div>
</template>

<script>
import { validationMixin } from "vuelidate";
import { required, email, minLength } from "vuelidate/lib/validators";
import userService from "../Services/userService";
export default {
  name: "FormValidation",
  mixins: [validationMixin],
  data: () => ({
    form: {
      fullname: null,
      email: null,
      password: null,
      phone: null,
    },
    userSaved: false,
    sending: false,
    loginUser: true,
  }),
  validations: {
    form: {
      fullname: {
        required,
      },
      email: {
        required,
        email,
      },
      password: {
        required,
        minLength: minLength(6),
      },
      phone: {
        required,
        minLength: minLength(10),
      },
    },
  },

  methods: {
    registerPost() {
      const userData = {
        fullName: this.form.fullname,
        email: this.form.email,
        password: this.form.password,
        mobile: this.phone,
      };
      userService
        .registration(userData)
        .then((data) => {
          setTimeout(() => this.$router.push("/"), 2000);
          console.log(data);
        })
        .catch((error) => {
          console.log(error);
        });
    },

    getValidationClass(fieldName) {
      const field = this.$v.form[fieldName];
      if (field) {
        return {
          "md-invalid": field.$invalid && field.$dirty,
        };
      }
    },

    redirect() {
      this.$router.push("/home");
    },

    clearForm() {
      this.$v.$reset();

      this.form.fullname = null;
      this.form.email = null;
      this.form.password = null;
      this.form.phone = null;
    },
    saveUser() {
      this.sending = true;

      window.setTimeout(() => {
        this.loginUser = `${this.form.email} `;
        this.userSaved = true;
        this.sending = false;
        this.clearForm();
      }, 1500);
    },
    validateUser() {
      this.$v.$touch();
      if (!this.$v.$invalid) {
        this.saveUser();
      }
    },
  }, // Methods
};
</script>

<style lang="scss" scoped>
.h2 {
  padding-bottom: 10px;
  margin-top: 1px;
  padding-top: 6px;
  font-family: Cambria, Cochin, Georgia, Times, "Times New Roman", serif;
  padding-bottom: 10px;
  border-radius: 14px;
}

.md-card-content {
  padding: 8px;
  font-size: 14px;
  line-height: 10px;
}
.blank {
  padding-bottom: 6px;
  border-radius: 20px;
}
.md-progress-bar {
  position: absolute;
  top: 0;
  right: 0;
  left: 0;
}
#md-card {
  // margin-left: 800px;
  display: flex;
  justify-content: center;
  margin-top: 150px;
  margin-left: 400px;
}

//Form
.md-layout {
  width: 700px;
  height: 40px;
}

//Text Forgot
#txt {
  //  text-transform: capitalize;
  border-bottom: 78px;
  margin-right: 80px;
  border-width: 4px;
}

#names {
  margin-bottom: 4px;
}

#namess {
  padding-bottom: 1px;
}

input[type="text"],
input[type="password"],
input[type="email"],
textarea,
select {
  padding: 12px 20px;
  margin: 12px 0;
  box-sizing: border-box;
  width: 80%;
  height: 30px;
  outline: none;
}

label {
  display: flex;
  justify-content: left;
  text-align: right;
  width: 100px;
  line-height: 8px;
  color: black;
  margin-left: 38px;
}
#fname {
  margin-top: 20px;
}

#txt1 {
  width: 240px;
  background-color: brown;
  text-transform: capitalize;
}

#txts {
  color: white;
  //  text-transform: capitalize;
  border-bottom: 8px solid brown;
  border-width: 4px;
  color: brown;
}

//Other Device 

@media (max-width: 600px) {

#md-card {
  // margin-left: 800px;
  display: flex;
  justify-content: center;
  margin-top: 100px;
  margin-left: 20px;

}

//Form
.md-layout {
  display: flex;
  width: 300px;
  height: 40px;
}
}

//IPAD 

@media (max-width: 768px) {

#md-card {
  // margin-left: 800px;
  display: flex;
  justify-content: center;
  // margin-top: 180px;
  margin-left: 60px;

}

//Form
.md-layout {
  display: flex;
  width: 600px;
  height: 80px;
}

input[type="text"],
input[type="password"],
input[type="email"],
textarea,
select {
  padding: 20px 24px;
  margin: 12px 0;
  box-sizing: border-box;
  width: 80%;
  height: 30px;
  outline: none;
}

label {
  display: flex;
  padding: 2px;
  justify-content: left;
  text-align: right;
  width: 100px;
  line-height: 10px;
  color: black;
  margin-left: 60px;
}

}

</style>
