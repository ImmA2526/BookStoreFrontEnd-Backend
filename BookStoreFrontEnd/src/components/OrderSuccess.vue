<template>
  <div class="maindiv">
    <div>
      <img
        src="@/assets/OrderSuccessfull.png"
        height="320"
        width="520"
        class="orderSuccess-image"
      />
    </div>
    <div id="para">
      <p class="success-message">
        hurray!!! your order is confirmed<br />
        the order id is #123456 save the order id for<br />
        further communication..
      </p>
    </div>
    <div id="allTable">
      <table class="table table-bordered">
        <thead class="thead-light">
          <tr>
            <th scope="col">Email US</th>
            <th scope="col">Contact Us</th>
            <th scope="col">Address</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              admin@bookstore.com
            </td>
            <td>
              +91 8163475881
            </td>
            <td>
              42, 14th Main, 15th Cross, Sector 4 ,opp to BDA<br />
              complex, near Kumarakom restaurant, HSR Layout,<br />
              Bangalore 560034
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <b-button id="button" to="./home" variant="primary">CONTINUE SHOPPING</b-button>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
#button {
  width: 240px;
  height: 29px;
  background: #3371b5 0% 0% no-repeat padding-box;
  border-radius: 2px;
  opacity: 1;
  font-size: 12px;
  text-align: center;
  margin-left: 254px;
  margin-top: 30px;
}

.maindiv {
  display: grid;
  justify-content: center;
}

#allTable {
  width: 800px;
}


@media (min-width: 360px) and(max-width:640px) {
#button {
  width: 240px;
  height: 29px;
  background: #3371b5 0% 0% no-repeat padding-box;
  border-radius: 2px;
  opacity: 1;
  font-size: 12px;
  text-align: center;
  margin-left: 254px;
  margin-top: 30px;
}

.maindiv {
  display: grid;
  justify-content: center;
}

#allTable {
  width: 800px;
}
}
</style>
