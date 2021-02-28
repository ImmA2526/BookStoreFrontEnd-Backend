<template>
  <div class="main">
    <form
      id="md-card"
      novalidate
      class="md-layout"
      @submit.prevent="validateUser"
    >
      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <center>
          <div class="h2">
            <p id="para">
              Please Enter Your Register Mail For Receving Mail Regarding Forgot
              Password.
            </p>
          </div>
        </center>

        <md-card-content>
          <div>
            <label>Email Id</label>
            <div>
              <input
                type="email"
                id="email"
                name="email"
                v-model="form.email"
              />
            </div>
          </div>
        </md-card-content>

        <md-progress-bar md-mode="indeterminate" v-if="sending" />

        <md-card-actions>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-button
                v-on:click="emailPost()"
                type="submit"
                id="lgbtn"
                class="md-dense md-raised md-primary"
                :disabled="sending"
                >Send Mail</md-button
              >
            </div>
          </div>
        </md-card-actions>
        <!-- <div class="blank"></div> -->
      </md-card>
      <!-- <md-snackbar :md-active.sync="userSaved">The user {{ loginUser }} successfully login!</md-snackbar> -->
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
    // Forgot Password
    emailPost() {
      userService
        .forgot(this.form.email)
        .then(function(data) {
          this.$router.push("/");
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
//Text Forgot
#txt {
  text-transform: capitalize;
}

#lgbtn {
  text-transform: capitalize;
  width: 240px;
  background-color: brown;
}

// Top Button >> Login SignUp
.h2 {
  padding-bottom: 6px;
  margin-top: 1px;
  padding-top: 6px;

  height: auto;
  font-size: 96%;
  font-family: Cambria, Cochin, Georgia, Times, "Times New Roman", serif;
}

//Inside Card
.md-card-content {
  padding: 4%;
  font-size: 14px;
  line-height: 10px;
}

//Progress Bar
.md-progress-bar {
  position: absolute;
  top: 0;
  right: 0;
  left: 0;
}

.main {
  display: flex;
  justify-content: center;
  width: 100%;
  height: 100%;
  background-color: white;

  //Form
  .md-layout {
    display: flex;
    justify-content: center;
    width: 46%;
    height: 84%;
    margin: auto;
  }

  //Whole Card
  #md-card {
    display: flex;
    justify-content: center;
    margin-top: 12%;
    margin-left: 30%;
  }
}

// Label Input

label {
  display: flex;
  justify-content: left;
  text-align: right;
  width: 100%;
  line-height: 8px;
  color: black;
  margin-left: 10%;
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

//Other Device
@media (min-width: 300px) and(max-width:640px) {
  //Form
  .main {
    display: flex;
    justify-content: center;
    width: 120%;
    height: 80%;
    background-color: white;

    //Form
    .md-layout {
      width: 120%;
      height: 50%;
      margin-right: 20px;
    }

    //Whole Card
    #md-card {
      display: flex;
      justify-content: center;
      margin-top: 12%;
      margin-left: 30%;
    }
  }
}

//IPAD Device

// @media (min-width: 750px) and(max-width:1030px) {
//   //Form
//   .main {
//     display: flex;
//     justify-content: center;
//     width: 140%;
//     height: 120%;
//     background-color: white;

//     //Form
//     .md-layout {
//       display: flex;
//       justify-content: center;
//       width: 60%;
//       height: 90%;
//       margin: auto;
//     }

//     //Whole Card
//     #md-card {
//       display: flex;
//       justify-content: center;
//       margin-top: 12%;
//       margin-left: 8%;
//     }
//   }

//   // Label Input

// label {
//   display: flex;
//   justify-content: left;
//   text-align: right;
//   width: 100%;
//   line-height: 8px;
//   color: black;
//   margin-left: 10%;
// }

// input[type="text"],
// input[type="password"],
// input[type="email"],
// textarea,
// select {
//   padding: 12px 20px;
//   margin: 12px 0;
//   box-sizing: border-box;
//   width: 80%;
//   height: 48px;
//   outline: none;
// }

// }
</style>
