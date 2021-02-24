<template>
  <div>
    <form novalidate class="md-layout" @submit.prevent="validateUser">
      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <center>
          <div class="h2">
            <md-button to="./" id="txt" class="md-primary" :disabled="sending">Login</md-button>
            <md-button to="./Register" id="txt" class="md-primary" :disabled="sending">SignUp</md-button>
                          
          </div>
        </center>

        <md-card-content>
          <md-field :class="getValidationClass('email')">
            <label for="email">Email</label>
            <md-input type="email" name="email" id="email" autocomplete="email" v-model="form.email" :disabled="sending"/>
            <span class="md-error" v-if="!$v.form.email.required">The email is required</span>
            <span class="md-error" v-else-if="!$v.form.email.email">Invalid email</span>
          </md-field>
          <md-field :class="getValidationClass('password')">
            <label for="password">Password</label>
            <md-input type="password" name="password" id="password" autocomplete="password" v-model="form.password" :disabled="sending"/>
            <span class="md-error" v-if="!$v.form.password.required">The password is required</span>
            <span class="md-error" v-else-if="!$v.form.password.minlength">Invalid password</span>
          </md-field>

          <md-button to="./Forgot" id="txt" class="md-primary">Forgot Password?</md-button>
        </md-card-content>

        <md-progress-bar md-mode="indeterminate" v-if="sending" />

        <md-card-actions>
          <div class="md-layout md-gutter">
            <div class="md-layout-item md-small-size-100">
              <md-button to="./Register" id="txt" class="md-primary" :disabled="sending">Create Account</md-button>
              <!-- <md-button  type="submit" class="md-primary" >Create account</md-button> -->
            </div>
            <div class="md-layout-item md-small-size-100">
              <md-button v-on:click="loginPost()" type="submit" id="txt" class="md-dense md-raised md-primary" :disabled="sending">Login</md-button>
           
            </div>
          </div>
        </md-card-actions>
        <div class="blank"></div>
      </md-card>
      <md-snackbar :md-active.sync="userSaved">The user {{ loginUser }} successfully login!</md-snackbar>
    </form>
  </div>
</template>

<script>
import { validationMixin } from "vuelidate";
import { required, email, minLength } from "vuelidate/lib/validators";

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
    
    getValidationClass(fieldName) {
      const field = this.$v.form[fieldName];
      if (field) {
        return {
          "md-invalid": field.$invalid && field.$dirty,
        };
      }
    }, 


     redirect() {
            this.$router.push("/home")
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
    
  },  // Methods 
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
.md-card {
  margin-left: 400px;
  margin-top: 150px;
}

//Form 
.md-layout {
    display: flex;
    flex-wrap: wrap;
   width: 800px;
   height: 70px;
    margin-left: 200px;
}

//Text Forgot 
#txt {
  text-transform: capitalize;
}

@media (max-width: 500px) {
 
 .md-layout {
    display: flex;
    flex-wrap: wrap;
   width: 300px;
   height: 60px;
    margin-left: 30px;
}

}
</style>