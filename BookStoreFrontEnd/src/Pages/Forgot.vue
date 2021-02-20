<template>
  <div>
    <form novalidate class="md-layout" @submit.prevent="validateUser">

      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <center>
          <div class="h2">
            <h2 id="h2">Book Store</h2>
            <h3>Forgot Password</h3>
          </div>
        </center>

        <md-card-content>
          <md-field :class="getValidationClass('email')">
            <label for="email">Email</label>
            <md-input type="email" name="email" id="email" autocomplete="email" v-model="form.email" :disabled="sending"/>
            <span class="md-error" v-if="!$v.form.email.required">The email is required</span>
            <span class="md-error" v-else-if="!$v.form.email.email">Invalid email</span>
          </md-field>
        </md-card-content>

        <md-progress-bar md-mode="indeterminate" v-if="sending" />

        <md-card-actions>
          <md-button type="submit" id="txt" v-on:click="emailPost()" class="md-dense md-raised md-primary" :disabled="sending">Send Mail</md-button>
        </md-card-actions>
        <div class="blank"></div>
      </md-card>
      <md-snackbar :md-active.sync="userSaved">The user {{ loginUser }} Password sent succesfully</md-snackbar>
    </form>
  </div>
</template>

<script>

import { validationMixin } from "vuelidate";
import { required, email } from "vuelidate/lib/validators";

export default {
  name: "FormValidation",
  mixins: [validationMixin],
  data: () => ({
    form: {
      email: null,
    },
    userSaved: false,
    sending: false,
     loginUser: true,
  }),
  validations: {
    form: {
      email: {
        required,
        email,
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
      this.form.email = null;
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

.md-progress-bar {
  position: absolute;
  top: 0;
  right: 0;
  left: 0;
}

.h2 {
  padding-bottom: 10px;
  padding-top: 6px;
  margin-top: 1px;
  font-family: Cambria, Cochin, Georgia, Times, "Times New Roman", serif;
  padding-bottom: 10px;
  border-radius: 14px;
}

//Bootom Page 
// .blank {
//   padding-bottom: 6px;
//   background-color: black;
//   border-radius: 20px;
// }

.md-card {
  margin-left: 400px;
  margin-top: 150px;
}
//Form 
.md-layout {
    display: flex;
    flex-wrap: wrap;
   width: 900px;
    margin-left: 200px;
}


//Text Forgot 
#txt {
  text-transform: capitalize;
}
</style>