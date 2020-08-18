  import React, { Component } from 'react';
  import { Form, Input, Button, Checkbox } from 'antd';
  import { UserManager} from 'oidc-client'
  import '../Asset/CSS/SignIn.css'
  import Id4Config from '../ConfigFile/IdentityServer4Config';
  class SignIn extends Component{
     constructor(props){
         super(props);
         this.state={
             username:"",
             password:""
         }
     }
    formRef=React.createRef();
    userManager=new UserManager(Id4Config);
      onFinish=(values)=> {
        console.log('Success:', values);
      };
    
       onFinishFailed = (errorInfo) => {
        console.log('Failed:', errorInfo);
      };
      Login(){
        this.userManager.

      }
     render(){
          return(
              <div className="SignIn-form">
                <div  className="SignIn-form-body">
        <Form  
           
            {...layout}
            name="basic"
            ref={this.formRef}
            initialValues={{ remember: true }}
            onFinish={this.onFinish}
            onFinishFailed={this.onFinishFailed}
          >
            <Form.Item
            
              name="username"
              rules={[{ required: true, message: '请输入账号！' }]}
            >
              <Input placeholder="用户名" />
            </Form.Item>     
            <Form.Item
             
              name="password"
              rules={[{ required: true, message: '请输入密码' }]}
            >
              <Input.Password placeholder="密码" />
            </Form.Item>
      
            <Form.Item  name="remember" valuePropName="checked">
              <Checkbox>记住我</Checkbox>
            </Form.Item>    
            <Form.Item>
              <Button type="primary" onClick={this.Login.bind(this)}>
               登录
              </Button>
            </Form.Item>
          </Form>
                </div>
         
              </div>
           
          )

     }
    
  }
  const layout = {
    wrapperCol: { span:12,offset:6}
  };
  const tailLayout = {
    wrapperCol: { offset: 8, span: 16 },
    labelAlign:"left"
  };   
  export default SignIn
  