using System.Collections.Frozen;
using VRCScalerOSC.Controller;
using VRCScalerOSC.Service;
using VRCScalerOSC.ViewModel;

namespace VRCScalerOSC.Model.SupportAvatarTool
{
    public class MagScaler(Controller_Scaler controller, ViewModel_Scaler viewModel) : SupportAvatarTool
    {
        private const int NewScale1xIndex = 73;
        private const int OldScale1xIndex = 50;

        private static readonly FrozenDictionary<int, float> NewScaleParameterMapping = new Dictionary<int, float>()
        {
            { 0, 0.01f },
            { 1, 0.010664949f },
            { 2, 0.011374114f },
            { 3, 0.012130436f },
            { 4, 0.012937048f },
            { 5, 0.013797296f },
            { 6, 0.014714746f },
            { 7, 0.015693203f },
            { 8, 0.016736722f },
            { 9, 0.01784963f },
            { 10, 0.019036539f },
            { 11, 0.020302372f },
            { 12, 0.021652376f },
            { 13, 0.02309215f },
            { 14, 0.024627663f },
            { 15, 0.026265277f },
            { 16, 0.028011784f },
            { 17, 0.02987443f },
            { 18, 0.03186093f },
            { 19, 0.033979516f },
            { 20, 0.036238983f },
            { 21, 0.03864869f },
            { 22, 0.04121863f },
            { 23, 0.043959465f },
            { 24, 0.046882547f },
            { 25, 0.05f },
            { 26, 0.053252053f },
            { 27, 0.056715626f },
            { 28, 0.060404476f },
            { 29, 0.06433325f },
            { 30, 0.06851755f },
            { 31, 0.07297401f },
            { 32, 0.077720314f },
            { 33, 0.08277533f },
            { 34, 0.08815913f },
            { 35, 0.093893096f },
            { 36, 0.1f },
            { 37, 0.106504105f },
            { 38, 0.11343125f },
            { 39, 0.12080895f },
            { 40, 0.1286665f },
            { 41, 0.1370351f },
            { 42, 0.14594802f },
            { 43, 0.15544063f },
            { 44, 0.16555066f },
            { 45, 0.17631826f },
            { 46, 0.18778619f },
            { 47, 0.2f },
            { 48, 0.21291952f },
            { 49, 0.22667363f },
            { 50, 0.2413162f },
            { 51, 0.25690466f },
            { 52, 0.27350008f },
            { 53, 0.29116756f },
            { 54, 0.3099763f },
            { 55, 0.33f },
            { 56, 0.35018167f },
            { 57, 0.37159753f },
            { 58, 0.39432317f },
            { 59, 0.41843855f },
            { 60, 0.44402882f },
            { 61, 0.47118407f },
            { 62, 0.5f },
            { 63, 0.5313293f },
            { 64, 0.5646216f },
            { 65, 0.6f },
            { 66, 0.644742f },
            { 67, 0.6928203f },
            { 68, 0.7444839f },
            { 69, 0.8f },
            { 70, 0.845897f },
            { 71, 0.89442724f },
            { 72, 0.94574165f },
            { 73, 1f },
            { 74, 1.0650411f },
            { 75, 1.1343125f },
            { 76, 1.2080895f },
            { 77, 1.286665f },
            { 78, 1.370351f },
            { 79, 1.4594802f },
            { 80, 1.5544063f },
            { 81, 1.6555066f },
            { 82, 1.7631825f },
            { 83, 1.8778619f },
            { 84, 2f },
            { 85, 2.1300821f },
            { 86, 2.268625f },
            { 87, 2.416179f },
            { 88, 2.57333f },
            { 89, 2.7407022f },
            { 90, 2.91896f },
            { 91, 3.1088126f },
            { 92, 3.3110132f },
            { 93, 3.526365f },
            { 94, 3.7557235f },
            { 95, 4f },
            { 96, 4.2670326f },
            { 97, 4.5518913f },
            { 98, 4.8557673f },
            { 99, 5.1799293f },
            { 100, 5.5257316f },
            { 101, 5.894619f },
            { 102, 6.2881327f },
            { 103, 6.7079163f },
            { 104, 7.1557245f },
            { 105, 7.633427f },
            { 106, 8.143021f },
            { 107, 8.686633f },
            { 108, 9.266536f },
            { 109, 9.885153f },
            { 110, 10.545067f },
            { 111, 11.249036f },
            { 112, 12f },
            { 113, 12.79123f },
            { 114, 13.634632f },
            { 115, 14.533645f },
            { 116, 15.491933f },
            { 117, 16.513409f },
            { 118, 17.602234f },
            { 119, 18.762854f },
            { 120, 20f },
            { 121, 21.210808f },
            { 122, 22.494923f },
            { 123, 23.856775f },
            { 124, 25.301077f },
            { 125, 26.832813f },
            { 126, 28.457287f },
            { 127, 30.180103f },
            { 128, 32.00722f },
            { 129, 33.944954f },
            { 130, 36f },
            { 131, 38.44466f },
            { 132, 41.055325f },
            { 133, 43.843277f },
            { 134, 46.820545f },
            { 135, 50f },
            { 136, 53.49566f },
            { 137, 57.23571f },
            { 138, 61.237247f },
            { 139, 65.51853f },
            { 140, 70.099144f },
            { 141, 75f },
            { 142, 79.441795f },
            { 143, 84.14664f },
            { 144, 89.13013f },
            { 145, 94.40875f },
            { 146, 100f },
            { 147, 106.504105f },
            { 148, 113.43125f },
            { 149, 120.808945f },
            { 150, 128.6665f },
            { 151, 137.0351f },
            { 152, 145.94801f },
            { 153, 155.44063f },
            { 154, 165.55066f },
            { 155, 176.31825f },
            { 156, 187.78618f },
            { 157, 200f },
            { 158, 213.98264f },
            { 159, 228.94284f },
            { 160, 244.94899f },
            { 161, 262.07413f },
            { 162, 280.39658f },
            { 163, 300f },
            { 164, 317.76718f },
            { 165, 336.58655f },
            { 166, 356.5205f },
            { 167, 377.635f },
            { 168, 400f },
            { 169, 429.1548f },
            { 170, 460.43457f },
            { 171, 493.9943f },
            { 172, 530f },
            { 173, 564.38727f },
            { 174, 601.00574f },
            { 175, 640f },
            { 176, 680.6914f },
            { 177, 723.96985f },
            { 178, 770f },
            { 179, 818.4742f },
            { 180, 870f },
            { 181, 932.7379f },
            { 182, 1000f },
            { 183, 1065.041f },
            { 184, 1134.3125f },
            { 185, 1208.0895f },
            { 186, 1286.6649f },
            { 187, 1370.351f },
            { 188, 1459.4802f },
            { 189, 1554.4062f },
            { 190, 1655.5066f },
            { 191, 1763.1825f },
            { 192, 1877.8618f },
            { 193, 2000f },
            { 194, 2119.2678f },
            { 195, 2245.6487f },
            { 196, 2379.5654f },
            { 197, 2521.4688f },
            { 198, 2671.834f },
            { 199, 2831.1663f },
            { 200, 3000f },
            { 201, 3223.7097f },
            { 202, 3464.1016f },
            { 203, 3722.4194f },
            { 204, 4000f },
            { 205, 4250.476f },
            { 206, 4516.6357f },
            { 207, 4799.463f },
            { 208, 5100f },
            { 209, 5443.0713f },
            { 210, 5809.2207f },
            { 211, 6200f },
            { 212, 6606.1465f },
            { 213, 7038.8994f },
            { 214, 7500f },
            { 215, 7969.939f },
            { 216, 8469.324f },
            { 217, 9000f },
            { 218, 9486.833f },
            { 219, 10000f },
            { 220, 10650.411f },
            { 221, 11343.125f },
            { 222, 12080.895f },
            { 223, 12866.649f },
            { 224, 13703.51f },
            { 225, 14594.802f },
            { 226, 15544.0625f },
            { 227, 16555.066f },
            { 228, 17631.826f },
            { 229, 18778.62f },
            { 230, 20000f },
            { 231, 21398.264f },
            { 232, 22894.285f },
            { 233, 24494.898f },
            { 234, 26207.414f },
            { 235, 28039.658f },
            { 236, 30000f },
            { 237, 32237.098f },
            { 238, 34641.016f },
            { 239, 37224.195f },
            { 240, 40000f },
            { 241, 42315.86f },
            { 242, 44765.8f },
            { 243, 47357.582f },
            { 244, 50099.42f },
            { 245, 53000f },
            { 246, 56438.73f },
            { 247, 60100.574f },
            { 248, 64000f },
            { 249, 68362.54f },
            { 250, 73022.445f },
            { 251, 78000f },
            { 252, 82849.266f },
            { 253, 88000f },
            { 254, 93808.31f },
            { 255, 100000f },
        }.ToFrozenDictionary();

        private static readonly FrozenDictionary<int, float> OldScaleParameterMapping = new Dictionary<int, float>()
        {
            { 31, 0.01f },
            { 32, 0.015f },
            { 33, 0.02f },
            { 34, 0.025f },
            { 35, 0.03f },
            { 36, 0.04f },
            { 37, 0.05f },
            { 38, 0.07f },
            { 39, 0.085f },
            { 40, 0.11f },
            { 41, 0.13f },
            { 42, 0.17f },
            { 43, 0.21f },
            { 44, 0.26f },
            { 45, 0.33f },
            { 46, 0.41f },
            { 47, 0.51f },
            { 48, 0.64f },
            { 49, 0.8f },
            { 50, 1f },
            { 51, 1.25f },
            { 52, 1.6f },
            { 53, 2.5f },
            { 54, 2.5f },
            { 55, 3f },
            { 56, 4f },
            { 57, 5f },
            { 58, 6f },
            { 59, 7.5f },
            { 60, 9f },
            { 61, 12f },
            { 62, 15f },
            { 63, 18f },
            { 64, 23f },
            { 65, 28f },
            { 66, 36f },
            { 67, 44f },
            { 68, 56f },
            { 69, 69f },
            { 70, 87f },
            { 71, 108f },
            { 72, 136f },
            { 73, 169f },
            { 74, 212f },
            { 75, 265f },
            { 76, 331f },
            { 77, 414f },
            { 78, 517f },
            { 79, 646f },
            { 80, 808f },
            { 81, 1010f },
            { 82, 1262f },
            { 83, 1578f },
            { 84, 1972f },
            { 85, 2465f },
            { 86, 3081f },
            { 87, 3852f },
            { 88, 4815f },
            { 89, 6019f },
            { 90, 7523f },
            { 91, 9404f },
            { 92, 11755f },
            { 93, 14693f },
            { 94, 18366f },
            { 95, 22957f },
            { 96, 28696f },
            { 97, 35870f },
            { 98, 44837f },
            { 99, 56046f },
            { 100, 70057f },
            { 101, 87571f },
            { 102, 100000f },
        }.ToFrozenDictionary();

        private static readonly IReadOnlyList<KeyValuePair<int, float>> SortedNewScaleParameterMapping =
            NewScaleParameterMapping.OrderBy(kvp => kvp.Value).ToList().AsReadOnly();

        private static readonly IReadOnlyList<KeyValuePair<int, float>> SortedOldScaleParameterMapping =
            OldScaleParameterMapping.OrderBy(kvp => kvp.Value).ToList().AsReadOnly();

        private float ScaleFactor = 1f;

        public override void InitOSCFunctions(OscEventCollection supportAbatarToolOSCFuns)
        {
            supportAbatarToolOSCFuns.AddEvent("/avatar/parameters/ScaleFactor", (isInitialized, service, data) =>
            {
                if (data.ValueF.HasValue)
                {
                    ScaleFactor = data.ValueF.Value;
                }
            });
            supportAbatarToolOSCFuns.AddEvent("/avatar/parameters/ScaleFactorInverse", (isInitialized, service, data) =>
            {
                if (data.ValueF.HasValue)
                {
                    ScaleFactorInverse = data.ValueF.Value;
                    DefaultEyeHeight = EyeHeightAsMeters * ScaleFactorInverse;
                }
            });
            supportAbatarToolOSCFuns.AddEvent("/avatar/parameters/EyeHeightAsMeters", (isInitialized, service, data) =>
            {
                if (data.ValueF.HasValue)
                {
                    EyeHeightAsMeters = data.ValueF.Value;
                    DefaultEyeHeight = EyeHeightAsMeters * ScaleFactorInverse;
                }
            });
        }
        public override Action<bool, Service_VRCOSCProtocols?, OSCData>? TryAddNewFunction(OSCData initialData)
        {
            if (initialData.Addr.StartsWith("/avatar/parameters/", StringComparison.Ordinal))
            {
                string param = initialData.Addr.ToString().Replace("/avatar/parameters/", "");
                if (param.Contains("ScaleOverlay") || param.Contains("NoReadyReset") || param.Contains("SelectAScale"))
                {
                    return (isInitialized, service, data) =>
                    {
                        if (isInitialized && data.ValueF.HasValue && data.ValueF.Value > 0.5f)
                        {
                            service?.SendOscMessage(new OSCData("/avatar/parameters/" + param, data.TypeString, 0));
                        }
                    };
                }
                else if (param.Contains("NextScale"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        SetScale(data.ValueI, NewScaleParameterMapping, NewScale1xIndex);
                        service?.SendOscMessage(new OSCData("/avatar/parameters/" + param, data.TypeString, NewScale1xIndex));
                    };
                }
                else if (param.Contains("LowerScale3"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        JumpScale(data.ValueB, -11, SortedNewScaleParameterMapping);
                    };
                }
                else if (param.Contains("LowerScale2"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        JumpScale(data.ValueB, -4, SortedNewScaleParameterMapping);
                    };
                }
                else if (param.Contains("LowerScale1"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        JumpScale(data.ValueB, -1, SortedNewScaleParameterMapping);
                    };
                }
                else if (param.Contains("RaiseScale1"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        JumpScale(data.ValueB, 1, SortedNewScaleParameterMapping);
                    };
                }
                else if (param.Contains("RaiseScale2"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        JumpScale(data.ValueB, 4, SortedNewScaleParameterMapping);
                    };
                }
                else if (param.Contains("RaiseScale3"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        JumpScale(data.ValueB, 11, SortedNewScaleParameterMapping);
                    };
                }
                else if (param.Contains("Scaled"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        SetScale(data.ValueI, OldScaleParameterMapping, OldScale1xIndex);
                        service?.SendOscMessage(new OSCData("/avatar/parameters/" + param, data.TypeString, OldScale1xIndex));
                    };
                }
                else if (param.Contains("Smaller"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        JumpScale(data.ValueB, -1, SortedOldScaleParameterMapping);
                    };
                }
                else if (param.Contains("Larger"))
                {
                    return (IsInitialized, service, data) =>
                    {
                        JumpScale(data.ValueB, 1, SortedOldScaleParameterMapping);
                    };
                }
            }
            return null;
        }

        private void SetScale(int? oscValue, FrozenDictionary<int, float> mapping, int scale1xIndex)
        {
            if (oscValue == null || oscValue == 0 || oscValue == scale1xIndex)
                return;

            if (mapping.TryGetValue(oscValue.Value, out float scaleFactor))
            {
                float NextEyeHeight = scaleFactor * DefaultEyeHeight;
                StartScaling(NextEyeHeight);
            }
        }

        private void JumpScale(bool? oscValue, int jumps, IReadOnlyList<KeyValuePair<int, float>> sortedScaleList)
        {
            if (oscValue == null || oscValue == false)
                return;

            int currentIndex = -1;

            // Find exact match or closest value using the saved ScaleFactor
            for (int i = 0; i < sortedScaleList.Count; i++)
            {
                if (MathF.Abs(sortedScaleList[i].Value - ScaleFactor) < 0.0001f)
                {
                    currentIndex = i;
                    break;
                }
            }

            // If no exact match found
            if (currentIndex == -1)
            {
                if (jumps > 0)
                {
                    // For positive jumps, find the closest scale down (floor)
                    for (int i = sortedScaleList.Count - 1; i >= 0; i--)
                    {
                        if (sortedScaleList[i].Value <= ScaleFactor)
                        {
                            currentIndex = i;
                            break;
                        }
                    }
                    if (currentIndex == -1)
                    {
                        // If no scale down found, default to the first scale
                        currentIndex = 0;
                    }
                }
                else
                {
                    // For negative jumps, find the closest scale up (ceiling)
                    for (int i = 0; i < sortedScaleList.Count; i++)
                    {
                        if (sortedScaleList[i].Value >= ScaleFactor)
                        {
                            currentIndex = i;
                            break;
                        }
                    }
                    if (currentIndex == -1)
                    {
                        // If no scale up found, default to the last scale
                        currentIndex = sortedScaleList.Count - 1;
                    }
                }
            }

            // Calculate the target index
            int targetIndex = currentIndex + jumps;

            // Clamp to valid range
            targetIndex = Math.Max(0, Math.Min(sortedScaleList.Count - 1, targetIndex));

            // Return the new eye height based on the target scale factor
            var nextEyeHeight = sortedScaleList[targetIndex].Value * DefaultEyeHeight;

            StartScaling(nextEyeHeight);
        }

        private void StartScaling(float scale)
        {
            if (scale < 0.01f)
            {
                scale = 0.01f;
            }
            if (scale > 10000)
            {
                scale = 10000;
            }

            controller.StartScaling(false, viewModel.FixedRate, scale, viewModel.ScalingTime, viewModel.ScalingRate);
        }
    }
}
