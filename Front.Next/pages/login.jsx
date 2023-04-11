import { MyTextInput } from "@/components/login/MyTextInput"
import { AuthLayout } from "@/layouts/AuthLayout"
import { HandleLogin, startLoginWithEmailAndPassword } from "@/store/auth/thunks";
import { Grid, TextField, Alert, Button, Google, Typography, Link } from "@mui/material"
import { Formik, Form, useFormik } from "formik"
import {  useRouter } from "next/router";
import { useDispatch } from "react-redux";
import * as Yup from "yup";


const login = () => {

  const dispatch = useDispatch();
  const router = useRouter();


  return (
    <AuthLayout title={"Login"}>

      <Formik
        initialValues={{ UserName: "", Password: "" }}
        onSubmit={(values, { setSubmitting }) => {  
          dispatch( startLoginWithEmailAndPassword(values) )
          router.push("/")
        }}
        validationSchema={Yup.object({
          UserName: Yup.string().email("Must be a valid email").required(),
          Password: Yup.string().required()
        })}
      >
        {({ values,
          errors,
          touched,
          handleChange,
          handleBlur,
          handleSubmit,
          isSubmitting,
        }) => (
          <form onSubmit={handleSubmit}>
            <Grid container>
              <MyTextInput label={"Email"}
                type={"email"}
                placeholder={"example@google.com"}
                name={"UserName"}
                value={values.UserName}
                onBlur={handleBlur}
                onChange={handleChange}
                errors={errors.UserName}
                // touched={touched.UserName}
              />

              <MyTextInput label={"Password"}
                type={"password"}
                placeholder={"********"}
                name={"Password"}
                value={values.Password}
                onBlur={handleBlur}
                onChange={handleChange}
                errors={errors.Password}
                // touched={touched.Password}
              />
            </Grid>


            <Grid
              container
              spacing={2}
              sx={{ mb: 2, mt: 1 }}
            >

              <Grid item xs={12} sm={6}>
                <Button
                  type="submit"
                  variant="contained"
                  fullWidth
                  sx={{ padding: 1 }}
                >
                  Login
                </Button>
              </Grid>


              <Grid item xs={12} sm={6}>
                <Link href="/register">
                  <Button
                    type="button"
                    variant="contained"
                    sx={{ backgroundColor: "tertiary.main", padding: 1 }}
                    fullWidth
                  >
                    Register
                  </Button>
                </Link>
              </Grid>
            </Grid>
            </form>
            )}
          </Formik>
  
  </AuthLayout>
  )
}

export default login