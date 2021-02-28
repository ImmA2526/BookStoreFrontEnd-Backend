<template>
  <div class="main">
    <form id="md-card" class="md-layout" novalidate @submit.prevent="validateUser">
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

        <div >
          <label>Full Name</label>
          <div >
            <input
              type="text"
              id="name"
              name="fullname"
              v-model="form.fullname"
            />
          </div>
        </div>

        <div >
          <label >Email Id</label>
          <div >
            <input type="email" id="email" name="email" v-model="form.email" />
          </div>
        </div>

        <div >
          <label >Password</label>
          <div >
            <input
              type="password"
              id="pass"
              name="password"
              v-model="form.password"
            />
          </div>
        </div>

        <div >
          <label id="phn">Phone Number</label>
          <div >
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
  // text-transform: capitalize;
  margin-right:14% ;
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
  // color: white;
  border-bottom: 8px solid brown;
  border-width: 4px;
  color: brown;
  margin-left: 20%;
  
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
