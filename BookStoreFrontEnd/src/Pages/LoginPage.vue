<template>
  <div class="md-layout">
    <form
      id="md-card"
      novalidate
      class="md-layout"
      @submit.prevent="validateUser"
    >
      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <center>
          <div class="h2">
            <md-button to="./" id="txts" class="md-primary" :disabled="sending"
              >Login</md-button
            >
            <md-button
              to="./Register"
              id="tt"
              class="md-primary"
              :disabled="sending"
              >SignUp</md-button
            >
          </div>
        </center>

        <md-card-content>
          <div class="form-group row">
            <label class="col-sm-2 col-form-label">Email Id</label>
            <div class="col-sm-8">
              <input
                type="email"
                id="email"
                name="email"
                v-model="form.email"
              />
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

          <md-button to="./Forgot" id="txt" class="md-primary"
            >Forgot Password?</md-button
          >
        </md-card-content>

        <md-progress-bar md-mode="indeterminate" v-if="sending" />

        <md-card-actions>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-button
                v-on:click="loginPost()"
                type="submit"
                id="lgbtn"
                class="md-dense md-raised md-primary"
                :disabled="sending"
                >Login</md-button
              >
            </div>
          </div>
        </md-card-actions>
        <!-- <div class="blank"></div> -->
      </md-card>
      <md-snackbar :md-active.sync="userSaved"
        >The user {{ loginUser }} successfully login!</md-snackbar
      >
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
      email: null,
      password: null,
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
      password: {
        required,
        minLength: minLength(6),
      },
    },
  },

  methods: {
    // loginUser
    loginPost() {
      const userData = {
        email: this.form.email,
        password: this.form.password,
      };
      userService
        .login(userData)
        .then((data) => {
          setTimeout(() => this.redirect(), 2000);
          this.$router.push("/Register");
          console.log(data);
        })
        .catch((error) => {
          console.log(error);
        });
    }, // Login User

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
      this.form.email = null;
      this.form.password = null;
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


</style>
