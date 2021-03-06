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

          <div>
            <label>Password</label>
            <div>
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
        .then((response) => {
          localStorage.setItem("AccessToken", response.data.data);
          localStorage.setItem("UserId", response.data.id);
          setTimeout(() => this.redirect(), 1400);
         
          // this.$router.push("/Register");
          console.log(response.data.data);
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
      this.$router.push("/nav");
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
//Top Button >> Login SignUp
.h2 {
  padding-bottom: 10px;
  margin-top: 1px;
  padding-top: 6px;
  font-family: Cambria, Cochin, Georgia, Times, "Times New Roman", serif;
  padding-bottom: 10px;
  border-radius: 14px;
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

//Text Forgot
#txt {
  text-transform: capitalize;
}

#lgbtn {
  text-transform: capitalize;
  width: 80%;
  background-color: brown;
}

#names {
  margin-bottom: 4px;
}

#namess {
  padding-bottom: 1px;
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
