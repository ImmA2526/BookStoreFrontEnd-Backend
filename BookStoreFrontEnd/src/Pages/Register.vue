<template>
  <div>
    <form novalidate class="md-layout" @submit.prevent="validateUser">
      <md-card class="md-layout-item md-size-50 md-small-size-100">
        <center>
          <div class="h2" id="namess">
            <md-button to="./" id="txt" class="md-primary" :disabled="sending">Login</md-button>
            <md-button to="./Register" id="txts" class="md-primary" :disabled="sending">SignUp</md-button>                     
          </div>
        </center>

    <div class="form-group row">
            <label id="fname" class="col-sm-2 col-form-label">Full Name</label>
            <div class="col-sm-8">
                <input type="text" id="name" name="fullname" >
            </div>
        </div>

    <div class="form-group row">
            <label class="col-sm-2 col-form-label">Email Id</label>
            <div class="col-sm-8">
                <input type="email" id="email" name="email" >
            </div>
        </div>


    
    <div class="form-group row">
            <label class="col-sm-2 col-form-label">Password</label>
            <div class="col-sm-8">
                <input type="password" id="pass" name="password" >
            </div>
        </div>

        <div class="form-group row">
            <label class="col-sm-2 col-form-label">Phone Number</label>
            <div class="col-sm-8">
                <input type="text" id="phone" name="phone" >
            </div>
        </div>
        <!-- <md-card-content>


          <md-button to="./Forgot" id="txt" class="md-primary">Forgot Password?</md-button>
        </md-card-content> -->

        <md-progress-bar md-mode="indeterminate" v-if="sending" />

        <md-card-actions>
          <div class="md-layout md-gutter">
            <!-- <div class="md-layout-item md-small-size-100">
              <md-button to="./Register" id="txt" class="md-primary" :disabled="sending">Create Account</md-button>
              <md-button  type="submit" class="md-primary" >Create account</md-button>
            </div> -->
            <div class="md-layout-item md-small-size-120">
              <md-button v-on:click="loginPost()" type="submit" id="txt1" class="md-dense md-raised md-primary" :disabled="sending">Login</md-button>
           
            </div>
          </div>
        </md-card-actions>
        <!-- <div class="blank"></div> -->
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
      firstName: null,
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
phone:{
required,
minLength:minLength(10),  
},
      firstName: {
        required,
       
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
      this.form.firstName = null;
      this.form.phone=null;
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
.md-card {
  margin-left: 400px;
  margin-top: 150px;
}




//Form 
.md-layout {
    display: flex;
    flex-wrap: wrap;
   width: 700px;
   height: 40px;
    margin-left: 200px;
}

//Text Forgot 
#txt {
  
  //  text-transform: capitalize;
  border-bottom: 78px;
  // color: red;
  margin-right: 80px;
      // border-bottom: 8px solid brown;
    border-width:4px ;

  // color: red;

}



#names
{
  margin-bottom: 4px;
}

#namess
{
  // padding-bottom: 10px;
      padding-bottom: 1px;
    // margin-top: -11px;
}


input[type="text"],
input[type="password"],
input[type="email"],
textarea,
select {
  padding: 12px 20px;
  margin: 12px 0;
  box-sizing: border-box;
  // border-radius: 8px;
  width: 80%;
  height: 30px;
  /* border-color:black;
*/
  // margin-right: 10%;
  outline: none;
}

label {
  display: flex;
  justify-content: left;
  text-align: right;
  width: 100px;
  line-height: 8px;
  // margin-left: 40px;
  color: black;
  margin-left: 38px;
}
s
#fname
{
  margin-top: 20px;
}

#txt1
{
  width: 240px;
  background-color:brown;
   text-transform: capitalize;

}



#txts
{
  color: white;
  //  text-transform: capitalize;

    border-bottom: 8px solid brown;
    border-width:4px ;
    // background-color: brown;
  color:brown;
  // margin-right: 70px;k
  // color: red;
}
@media (max-width: 500px) {
 
 .md-layout {
    display: flex;
    flex-wrap: wrap;
   width: 300px;
   height: 70px;
    margin-left: 40px;
  // padding-bottom: 80px;
}

.md-card {
  margin-left: 200px;
  margin-top: 70px;
}


}

</style>