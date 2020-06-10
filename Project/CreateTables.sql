Drop Database If Exists ThesisProject;
Go

Create Database ThesisProject;
Go

Use ThesisProject;
Go

Create Table NeuralNetwork(
	Id Integer Identity(1, 1),
	NumberOfNeuron Integer Not NULL,
	NumberOfLayer Integer Not NULL,
	OutputValue Float,
	Primary Key(NumberOfNeuron, NumberOfLayer)
);

Create Table DataSet (
	Id Integer Identity(1, 1) Primary Key,
	Id_Orig_H VarChar(100),
	Id_Resp_H VarChar(100),
	Id_Orig_P Integer,
	Id_Resp_P Integer,
	Protocol VarChar(10),
	Service_Protocol VarChar(100),
	Missed_Bytes Integer,
	Duration Float,
	Orig_Bytes Integer,
	Resp_Bytes Integer,
	Connection_State VarChar(100),
	Local_Orig Bit,
	Local_Resp Bit,
	History VarChar(100),
	Orig_Pkts Integer,
	Orig_Ip_Bytes Integer,
	Resp_Pkts Integer,
	Resp_Ip_Bytes Integer,
	Label_Value Integer
);

Create Table IntrusionDetections (
	Id Integer Identity(1, 1) Primary Key,
	Id_Orig_H VarChar(100),
	Id_Resp_H VarChar(100),
	Id_Orig_P Integer,
	Id_Resp_P Integer,
	Protocol VarChar(10),
	Service_Protocol VarChar(100),
	Missed_Bytes Integer,
	Duration Float,
	Orig_Bytes Integer,
	Resp_Bytes Integer,
	Connection_State VarChar(100),
	Local_Orig Bit,
	Local_Resp Bit,
	History VarChar(100),
	Orig_Pkts Integer,
	Orig_Ip_Bytes Integer,
	Resp_Pkts Integer,
	Resp_Ip_Bytes Integer,
	TimeOfDetection DateTime
);


Create Table NeuralLinks(
	Id Integer Identity(1, 1),
	PreviousLayer Integer NOT NULL,
	NextLayer Integer Not NULL,
	PreviousNeuron Integer Not NULL,
	NextNeuron Integer NOT NULL,
	WeightValue Float,
	Delta Float,
	PreviousWeightValue Float
	Primary Key(PreviousLayer, NextLayer, PreviousNeuron, NextNeuron)
);

GO