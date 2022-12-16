#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Single UnityEngine.WheelCollider::get_radius()
extern void WheelCollider_get_radius_m68CC3DE301E0C6226E85F99D853365DA1244CD1F (void);
// 0x00000002 System.Void UnityEngine.WheelCollider::set_motorTorque(System.Single)
extern void WheelCollider_set_motorTorque_m4958AAF7D867CF7570420F9BAFAF04DC904F02A8 (void);
// 0x00000003 System.Void UnityEngine.WheelCollider::set_brakeTorque(System.Single)
extern void WheelCollider_set_brakeTorque_mB9B216C57C275470907C7DB35185E2F192DC8DAB (void);
// 0x00000004 System.Void UnityEngine.WheelCollider::set_steerAngle(System.Single)
extern void WheelCollider_set_steerAngle_m7BF83B27D8956355F873537939BE9F35CF3113C3 (void);
// 0x00000005 System.Single UnityEngine.WheelCollider::get_rpm()
extern void WheelCollider_get_rpm_m7AFAA813ED3965AE4B2A2E7CBC6FB2B26B68ED52 (void);
// 0x00000006 System.Void UnityEngine.WheelCollider::GetWorldPose(UnityEngine.Vector3&,UnityEngine.Quaternion&)
extern void WheelCollider_GetWorldPose_m8C41FA2AE9ED543AB94A6E3226523A2FE83FA890 (void);
static Il2CppMethodPointer s_methodPointers[6] = 
{
	WheelCollider_get_radius_m68CC3DE301E0C6226E85F99D853365DA1244CD1F,
	WheelCollider_set_motorTorque_m4958AAF7D867CF7570420F9BAFAF04DC904F02A8,
	WheelCollider_set_brakeTorque_mB9B216C57C275470907C7DB35185E2F192DC8DAB,
	WheelCollider_set_steerAngle_m7BF83B27D8956355F873537939BE9F35CF3113C3,
	WheelCollider_get_rpm_m7AFAA813ED3965AE4B2A2E7CBC6FB2B26B68ED52,
	WheelCollider_GetWorldPose_m8C41FA2AE9ED543AB94A6E3226523A2FE83FA890,
};
static const int32_t s_InvokerIndices[6] = 
{
	3419,
	2838,
	2838,
	2838,
	3419,
	1249,
};
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_UnityEngine_VehiclesModule_CodeGenModule;
const Il2CppCodeGenModule g_UnityEngine_VehiclesModule_CodeGenModule = 
{
	"UnityEngine.VehiclesModule.dll",
	6,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
