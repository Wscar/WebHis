import React, { useState} from 'react';
import { Form, Input, Button, Checkbox, Layout,Divider } from 'antd';
export default LoginView
function LoginView(props){
    const [userName,setUserName]=useState(0)
    const Login=()=>{

        props.history.push('/home')
    }
     console.log(props);
     const layout = {
        labelCol: { span: 10 },
        wrapperCol: { span: 5},
      };
      const tailLayout = {
        wrapperCol: { offset: 10, span: 2 },
      };
    return(
        <div className="login">
            <Divider orientation="left">Left Text</Divider>
              <Form
        {...layout}
        name="basic"
        initialValues={{ remember: true }}
        layout="horizontal"
        size="middle"
      >
        <Form.Item
          label="Username"
          name="username"
          rules={[{ required: true, message: 'Please input your username!' }]}
        >
          <Input placeholder="请输入账号" size="middle" />
        </Form.Item>
  
        <Form.Item
          label="Password"
          name="password"
          rules={[{ required: true, message: 'Please input your password!' }]}
        >
          <Input.Password  placeholder="请输入密码" size="middle" />
        </Form.Item>
  
        <Form.Item {...tailLayout} name="remember" valuePropName="checked">
          <Checkbox>Remember me</Checkbox>
        </Form.Item>
  
        <Form.Item {...tailLayout}>
          <Button type="primary" htmlType="submit" onClick={Login}>
            Submit
          </Button>
        </Form.Item>
      </Form>
        </div>
      
    )
}
