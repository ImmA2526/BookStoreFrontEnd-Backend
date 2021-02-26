<template>
  <div class="md-layout">
    <!-- <form > -->
    <form
      id="md-card"
      novalidate
      class="md-layout"
      @submit.prevent="validateUser"
    >
      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <center>
          <div class="h2">
            <h2 id="h2">Book Store</h2>
            <h3>Reset Password</h3>
          </div>
        </center>

        <md-card-content>
          <md-field :class="getValidationClass('password')">
            <label for="password">Old Password</label>
            <md-input
              type="password"
              name="password"
              id="password"
              autocomplete="password"
              :disabled="sending"
            />
            <span class="md-error" v-if="!$v.form.password.required"
              >The password is required</span
            >
            <span class="md-error" v-else-if="!$v.form.password.minlength"
              >Invalid password</span
            >
          </md-field>
          <!-- New password for reseting -->
          <md-field :class="getValidationClass('password')">
            <label for="password">New Password</label>
            <md-input
              type="password"
              name="newPassword"
              id="password"
              v-model="form.password"
              :disabled="sending"
            />
            <span class="md-error" v-if="!$v.form.cpassword.required"
              >The password is required</span
            >
            <span class="md-error" v-else-if="!$v.form.cpassword.minlength"
              >Invalid password</span
            >
          </md-field>

          <md-field :class="getValidationClass('password')">
            <label for="Newpassword">Confirm Password</label>
            <md-input
              type="password"
              name="Confirmpassword"
              id="cpass"
              v-model="form.password"
              :disabled="sending"
            />
            <span class="md-error" v-if="!$v.form.cpassword.required"
              >The password is required</span
            >
            <span class="md-error" v-else-if="!$v.form.cpassword.minlength"
              >Invalid password</span
            >
          </md-field>
        </md-card-content>

        <md-progress-bar md-mode="indeterminate" v-if="sending" />

        <md-card-actions>
          <md-button
            v-on:click="put"
            type="submit"
            id="txt"
            class="md-dense md-raised md-primary"
            :disabled="sending"
            >Reset</md-button
          >
        </md-card-actions>
        <div class="blank"></div>
      </md-card>
      <md-snackbar :md-active.sync="userSaved"
        >The user {{ loginUser }} successfully login!</md-snackbar
      >
    </form>
  </div>
</template>

<script>
// import axios from 'axios'

import { validationMixin } from "vuelidate";
import { required, minLength } from "vuelidate/lib/validators";

export default {
  name: "FormValidation",
  mixins: [validationMixin],
  data: () => ({
    form: {
      password: null,
      cpassword: null,
    },
    userSaved: false,
    sending: false,
  }),

  validations: {
    form: {
      password: {
        required,
        minLength: minLength(8),
      },
      // resetpwd
      cpassword: {
        required,
        minLength: minLength(8),
      },
    },
  },
  methods: {
    getValidationClass(fieldName) {
      const field = this.$v.form[fieldName];

      if (field) {
        return {
          "md-invalid": field.$invalid && field.$dirty,
        };
      }
    },

    clearForm() {
      this.$v.$reset();
      this.form.password = null;
      this.form.cpassword = null;
    },
    saveUser() {
      this.sending = true;

      // Instead of this timeout, here you can call your API
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
  },
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
  //  background-color: black;
  border-radius: 20px;
}
.md-progress-bar {
  position: absolute;
  top: 0;
  right: 0;
  left: 0;
}

#md-card {
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
  text-transform: capitalize;
}

#lgbtn {
  text-transform: capitalize;
  width: 240px;
  background-color: brown;
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
  //  text-transform: capitalize;
}

#txts {
  color: white;
  border-bottom: 8px solid brown;
  border-width: 4px;
  color: brown;
  margin-right: 70px;
}

//IPAD 

@media (max-width: 768px) {

#md-card {
  // margin-left: 800px;
  display: flex;
  justify-content: center;
  margin-top: 180px;
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

//Other Device 

@media (max-width: 100px) {

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
</style>
