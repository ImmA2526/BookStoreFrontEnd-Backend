<template>
  <div>
    <form novalidate class="md-layout" @submit.prevent="validateUser">
    
    <!-- <form novalidate class="md-layout" @submit.prevent="validateUser()" > -->
      <md-card class="md-layout-item md-size-50 md-small-size-50 md-with-hover">
        
        <center><div class="h2">
      <h2 id=h2>Book Store</h2>
      <h3>Registraion Page</h3>
    </div></center>
        <div>

          <md-card-content>
            <div class="md-layout md-gutter">
              <div class="md-layout-item md-small-size-100">
                <md-field :class="getValidationClass('firstName')">
                  <label for="first-name">First Name</label>
                  <md-input name="first-name" id="first-name" autocomplete="given-name" v-model="form.firstName" :disabled="sending" />
                  <span class="md-error" v-if="!$v.form.firstName.required" >The first name is required</span>
                  <span class="md-error" v-else-if="!$v.form.firstName.minlength">Invalid first name</span>
                </md-field>
              </div>

              <div class="md-layout-item md-small-size-100">
                <md-field :class="getValidationClass('lastName')">
                  <label for="last-name">Last Name</label>
                  <md-input name="last-name" id="last-name" autocomplete="family-name" v-model="form.lastName" :disabled="sending"/>
                  <span class="md-error" v-if="!$v.form.lastName.required">The last name is required</span>
                  <span class="md-error" v-else-if="!$v.form.lastName.minlength">Invalid last name</span>
                </md-field>
              </div>
            </div>

               <!-- <md-card-content> -->
          <md-field :class="getValidationClass('email')">
            <label for="email">Email</label>
            <md-input type="email" name="email" id="email" autocomplete="email" v-model="form.email" :disabled="sending" />
            <span class="md-error" v-if="!$v.form.email.required">The email is required</span>
            <span class="md-error" v-else-if="!$v.form.email.email">Invalid email</span>
          </md-field>

            <div class="md-layout md-gutter">
              <div class="md-layout-item md-small-size-100">
                <md-field :class="getValidationClass('password')">
                  <label for="last-name">Password</label>
                  <md-input type="password" name="password" id="password" autocomplete="password" v-model="form.password" :disabled="sending" />
                  <span class="md-error" v-if="!$v.form.password.required">The password is required</span>
                  <span class="md-error" v-else-if="!$v.form.password.minlength">Invalid password</span>
                </md-field>
              </div>

              <div class="md-layout-item md-small-size-100">
                <md-field :class="getValidationClass('confirm')">
                  <label for="last-name">Confirm</label>
                  <md-input type="password" name="confirm" id="confirm" autocomplete="confirm" v-model="form.confirm" :disabled="sending" />
                  <span class="md-error" v-if="!$v.form.confirm.required">The confirm is required</span>
                  <span class="md-error" v-else-if="!$v.form.confirm.minlength">Invalid confirm</span>
                </md-field>
              </div>
            </div>
          </md-card-content>

          <md-progress-bar md-mode="indeterminate" v-if="sending" />
        </div>

        <md-card-actions>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-button type="submit" to="./" class="md-primary" :disabled="sending">Sign in instead</md-button>
            </div>
            <div class="md-layout-item md-small-size-100">
              <md-button  v-on:click="registerPost()" type="submit" class="md-dense md-raised md-primary" :disabled="sending" >SignUp</md-button>
              <!-- <md-button  v-on:click="post" type="submit" class="md-dense md-raised md-primary" :disabled="sending" >SignUp</md-button> -->
            </div>
          </div>
        </md-card-actions>
        <div class="blank"></div>
      </md-card>
    </form>
  </div>
</template>

<script>
import {validationMixin} from "vuelidate";
import {required,email,minLength,maxLength} from "vuelidate/lib/validators";
import UserServices from "../Services/UserServices";
// import axios from "axios";

export default {
  name: "FormValidation",
  mixins: [validationMixin],
  data: () => ({
    form: {
      firstName: null,
      lastName: null,
      email: null,
      password: null,
      confirm: null
    },
    userSaved: false,
    sending: false,
    lastUser: null
  }),
  validations: {
    form: {
      firstName: {
        required,
        minLength: minLength(4)
      },
      lastName: {
        required,
        minLength: minLength(4)
      },
      email: {
        required,
        email
      },
      password: {
        required,
        maxLength: maxLength(8)
      },
      confirm: {
        required
        // target:password
      }
    }
  },
  methods: {
    getValidationClass(fieldName) {
      const field = this.$v.form[fieldName];

      if (field) {
        return {
          "md-invalid": field.$invalid && field.$dirty
        };
      }
    },

registerPost() {
const userData = {

    lastName:this.form.lastName,
        firstName:this.form.firstName,
        email:this.form.email,
        password:this.form.password,
      };
     UserServices
        .registration(userData)
        .then((data)=> {
          // localStorage.setItem("AccessToken", data.data.id);

           setTimeout(()=>  this.$router.push("/home"), 2000)
          // this.$router.push("/home");
          // window.location.href="/";
          console.log(data);
        })
        .catch((error) => {
          console.log(error);
        });
    },

    clearForm() {
      this.$v.$reset();
      this.form.firstName = null;
      this.form.lastName = null;
      this.form.email = null;
      this.form.password = null;
      this.form.confirm = null;
    },
    saveUser() {
      this.sending = true;
      // Instead of this timeout, here you can call your API
      window.setTimeout(() => {
        this.lastUser = `${this.form.firstName} ${this.form.lastName}`;
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
    }
  }
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
margin-top: 1px;
padding-top: 6px;
font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
// color:rgb(14, 14, 14);
padding-bottom: 10px;
// background-color: rgba(200, 152, 228, 0.699);
border-radius: 14px;
}
#h2
{
color:rgb(25, 6, 192);
}

.blank
{
padding-bottom: 8px;
// background-color:rgba(200, 152, 228, 0.699);
border-radius: 10px;
}
.md-card {
margin-left: 400px;
margin-top: 150px;
}
</style>